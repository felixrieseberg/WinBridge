using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETFX_CORE
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Store;
using Windows.Storage;
using Windows.Storage.Streams;
#endif

#if WINDOWS_PHONE

#endif

namespace WinControls
{
    public class MessageBox
    {
        public delegate void ActionDelegate(object UICommand);

        public class Command
        {
            public string text;
            public ActionDelegate action;

            public Command(string text, ActionDelegate action)
            {
                this.text = text;
                this.action = action;
            }
        }

        public string ShowMessageBox(string message)
        {
            return ShowMessageBox(message, null, null, null);
        }

        public string ShowMessageBox(string message, string title, Command command1)
        {
            return ShowMessageBox(message, title, command1, null);
        }

        public string ShowMessageBox(string message, string title, Command command1, Command command2)
        {
#if NETFX_CORE
            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                MessageDialog messageBox = new MessageDialog(message, title);

                if (command1 != null)
                {
                    messageBox.Commands.Add(new UICommand(command1.text, new UICommandInvokedHandler(command1.action)));
                }

                if (command2 != null)
                {
                    messageBox.Commands.Add(new UICommand(command2.text, new UICommandInvokedHandler(command2.action)));
                }

                messageBox.ShowAsync();
            });
            return "winrt";
#else
            return "stub";
#endif
        }
    }

    public class Store
    {
        public enum PurchaseResult
        {
            PurchaseSuccess,
            PurchaseCancel,
            PurchaseError,
            AlreadyPurchased
        }

        public delegate void ActionDelegate(PurchaseResult result);

        public static void PurchaseFullApp(ActionDelegate purchaseCallback)
        {
            PurchaseFullApp(purchaseCallback, false);
        }
        public static void PurchaseFullApp(ActionDelegate purchaseCallback, bool isDebug)
        {
#if NETFX_CORE
            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                PurchaseFullAppAsync(purchaseCallback, isDebug);
            });
#endif
        }

        public static bool IsFullAppActive()
        {
            return IsFullAppActive(false);

        }

        public static bool IsFullAppActive(bool isDebug)
        {
            bool isActive = false;
#if NETFX_CORE

            if (isDebug)
            {
                isActive = CurrentAppSimulator.LicenseInformation.IsActive;
            }
            else
            {
                isActive = CurrentApp.LicenseInformation.IsActive;
            }
#endif
            return isActive;
        }

        public static void PurchaseProduct(string productName, ActionDelegate callBack)
        {
            PurchaseProduct(productName, callBack, false);

        }

        public static void PurchaseProduct(string productName, ActionDelegate purchaseCallback, bool isDebug)
        {
#if NETFX_CORE
            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                PurchaseProductAsync(productName, purchaseCallback, isDebug);
            });
#endif
        }

        public static bool IsProductActive(string productName)
        {
            return IsProductActive(productName, false);

        }

        public static bool IsProductActive(string productName, bool isDebug)
        {
            bool isActive = false;
#if NETFX_CORE

            if (isDebug)
            {
                isActive = CurrentAppSimulator.LicenseInformation.ProductLicenses[productName].IsActive;
            }
            else
            {
                isActive = CurrentApp.LicenseInformation.ProductLicenses[productName].IsActive;
            }
#endif
            return isActive;
        }

        public static void EnableWindowsStoreProxy(string windowsStoreProxy, bool isDebug)
        {
#if NETFX_CORE
            if (isDebug) 
            {
                WriteWindowsStoreProxyFile(windowsStoreProxy);
            }
#endif
        }

#if NETFX_CORE
        // Internal Windows-only functions

        protected async static void WriteWindowsStoreProxyFile(string windowsStoreProxy)
        {

            // Get or create the folder, create or replace the destination file
            StorageFolder destinationFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("WindowsStoreProxy", CreationCollisionOption.OpenIfExists);
            StorageFile destinationFile = await destinationFolder.CreateFileAsync("WindowsStoreProxy.xml", CreationCollisionOption.OpenIfExists);

            // Write string to file
            // Note: The wrong encoding will lead to a nasty exception
            await Windows.Storage.FileIO.WriteTextAsync(destinationFile, windowsStoreProxy, Windows.Storage.Streams.UnicodeEncoding.Utf16LE);

            // Reload CurrentAppSimulator with created WindowsStoreProxy
            await CurrentAppSimulator.ReloadSimulatorAsync(destinationFile);
        }

        protected async static void PurchaseFullAppAsync(ActionDelegate purchaseCallback, bool isDebug)
        {
            if (!IsFullAppActive(isDebug))
            {
                try
                {
                    if (isDebug)
                    {

                        await CurrentAppSimulator.RequestAppPurchaseAsync(false);
                        PurchaseResult purchaseResult = IsFullAppActive(isDebug) ? PurchaseResult.PurchaseSuccess : PurchaseResult.PurchaseCancel;
                        purchaseCallback(purchaseResult);
                    }
                    else
                    {
                        await CurrentApp.RequestAppPurchaseAsync(false);
                        PurchaseResult purchaseResult = IsFullAppActive(isDebug) ? PurchaseResult.PurchaseSuccess : PurchaseResult.PurchaseCancel;
                        purchaseCallback(purchaseResult);
                    }
                }
                catch
                {
                    purchaseCallback(PurchaseResult.PurchaseError);
                }
            }
            else
            {
                purchaseCallback(PurchaseResult.AlreadyPurchased);
            }
      
        }
        protected async static void PurchaseProductAsync(string productName, ActionDelegate purchaseCallback, bool isDebug)
        {
            if (!IsProductActive(productName, isDebug))
            {
                try
                {
                    if (isDebug)
                    {

                        await CurrentAppSimulator.RequestProductPurchaseAsync(productName, false);
                        PurchaseResult purchaseResult = IsProductActive(productName, isDebug) ? PurchaseResult.PurchaseSuccess : PurchaseResult.PurchaseCancel;
                        purchaseCallback(purchaseResult);
                    }
                    else
                    {
                        await CurrentApp.RequestProductPurchaseAsync(productName, false);
                        PurchaseResult purchaseResult = IsProductActive(productName, isDebug) ? PurchaseResult.PurchaseSuccess : PurchaseResult.PurchaseCancel;
                        purchaseCallback(purchaseResult);
                    }
                }
                catch
                {
                    purchaseCallback(PurchaseResult.PurchaseError);
                }
            }
            else
            {
                purchaseCallback(PurchaseResult.AlreadyPurchased);
            }
        }

#endif
    }
}
