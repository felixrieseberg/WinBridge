using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

#if NETFX_CORE
using System.Threading.Tasks;
using System.IO;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Store;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
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

        public void ShowMessageBox(string message)
        {
            ShowMessageBox(message, null, null, null);
        }

        public void ShowMessageBox(string message, string title, Command command1)
        {
            ShowMessageBox(message, title, command1, null);
        }

        public void ShowMessageBox(string message, string title, Command command1, Command command2)
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
#endif
        }
    }

    public class VideoPlayback {

        public static void PlayVideoFullscreen(string videoUrl)
        {
            PlayVideoFullscreen(videoUrl, true, false);
        }
        public static void PlayVideoFullscreen(string videoUrl, bool controlsEnabled)
        {
            PlayVideoFullscreen(videoUrl, controlsEnabled, false);
        }
        public static void PlayVideoFullscreen(string videoUrl, bool controlsEnabled, bool tapSkipsVideo)
        {
#if NETFX_CORE
            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {

                Page page = (Page)Window.Current.Content;
                SwapChainBackgroundPanel backgroundPanel = (SwapChainBackgroundPanel)page.FindName("DXSwapChainBackgroundPanel");

                MediaElement videoPlayBackElement = new MediaElement();

                videoPlayBackElement.IsFullWindow = true;
                videoPlayBackElement.Source = new Uri(videoUrl);
                videoPlayBackElement.AreTransportControlsEnabled = controlsEnabled;

                if (tapSkipsVideo)
                {
                    videoPlayBackElement.Tapped += delegate { backgroundPanel.Children.Remove(videoPlayBackElement); };
                }
                videoPlayBackElement.MediaEnded += delegate { backgroundPanel.Children.Remove(videoPlayBackElement); };

                backgroundPanel.Children.Add(videoPlayBackElement);
            
                videoPlayBackElement.Play();
            });
#endif
        }

    }

    public class Store
    {
        public class FullAppInfo
        {
            public string Name;
            public string Description;
            public string Market;
            public uint AgeRating;
            public string Price;
        }

        public class ProductInfo
        {
            public string Name;
            public string Id;
            public string Price;
        }

        public class DebugApp
        {
            public Guid AppId = new Guid("2B14D306-D8F8-4066-A45B-0FB3464C67F2");
            public Uri LinkUri = new Uri("http://apps.microsoft.com/webpdp/app/2B14D306-D8F8-4066-A45B-0FB3464C67F2");
            public string CurrentMarket = "en-US";
            public uint AgeRating = 3;
            public string Name = "Debug App";
            public string Description = "This is a debug app";
            public double Price = 1.99;
            public string CurrencySymbol = "$";
            public string CurrencyCode = "USD";
            public bool? IsActive = false;
            public bool? IsTrial = true;

        }

        public class DebugProduct
        {
            public string ProductId = "product1";
            public string Name = "Product 1";
            public double Price = 0.99;
            public string CurrencySymbol = "$";
            public string CurrencyCode = "USD";
            public bool? IsActive = false;
        }

        public enum PurchaseResult
        {
            PurchaseSuccess,
            PurchaseCancel,
            PurchaseError,
            AlreadyPurchased
        }


        public delegate void PurchaseResultHandler(PurchaseResult result);
        public delegate void FullAppInfoHandler(FullAppInfo result);
        public delegate void ProductInfoHandler(ProductInfo result);
        public delegate void LicenseChangedHandler();

        public static void PurchaseFullApp(PurchaseResultHandler purchaseCallback)
        {
            PurchaseFullApp(purchaseCallback, false);
        }
        public static void PurchaseFullApp(PurchaseResultHandler purchaseCallback, bool isDebug)
        {
#if NETFX_CORE

            PurchaseFullAppAsync(purchaseCallback, isDebug);
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

        public static void GetFullAppInfo(FullAppInfoHandler fullAppInfoCallback, bool isDebug)
        {

#if NETFX_CORE
            GetFullAppInfoAsync(fullAppInfoCallback, isDebug);
#endif

        }

        public static void PurchaseProduct(string productName, PurchaseResultHandler purchaseCallback)
        {
            PurchaseProduct(productName, purchaseCallback, false);

        }

        public static void PurchaseProduct(string productName, PurchaseResultHandler purchaseCallback, bool isDebug)
        {
#if NETFX_CORE
            PurchaseProductAsync(productName, purchaseCallback, isDebug);
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

        public static void GetProductInfo(string productName, ProductInfoHandler productInfoCallback, bool isDebug)
        {
#if NETFX_CORE
            GetProductInfoAsync(productName, productInfoCallback, isDebug);
#endif
        }

        public static void EnableDebugWindowsStoreProxy(DebugApp debugApp, params DebugProduct[] debugProducts)
        {
            EnableDebugWindowsStoreProxy(null, debugApp, debugProducts);
        }

        public static void EnableDebugWindowsStoreProxy(LicenseChangedHandler licenseChangedHandler, DebugApp debugApp, params DebugProduct[] debugProducts)
        {
#if NETFX_CORE
            XElement proxyXML = SerializeStoreProxyToXML(debugApp, debugProducts);
            using (StringWriter proxyXMLWriter = new StringWriter())
            {
                proxyXML.Save(proxyXMLWriter, SaveOptions.DisableFormatting);
                EnableDebugWindowsStoreProxy(licenseChangedHandler, proxyXMLWriter.ToString());
            }
#endif
        }


        public static void EnableDebugWindowsStoreProxy(string windowsStoreProxy)
        {
            EnableDebugWindowsStoreProxy(null, windowsStoreProxy);
        }

        public static void EnableDebugWindowsStoreProxy(LicenseChangedHandler licenseChangedHandler, string windowsStoreProxy)
        {
#if NETFX_CORE
            if (licenseChangedHandler != null)
            {
                LicenseChangedEventHandler licenseChangedEventHandler = new LicenseChangedEventHandler(licenseChangedHandler);
                CurrentAppSimulator.LicenseInformation.LicenseChanged += licenseChangedEventHandler;
            }

            WriteWindowsStoreProxyFileAsync(windowsStoreProxy);
#endif
        }

#if NETFX_CORE
        // Internal Windows-only functions
        protected static XElement SerializeStoreProxyToXML(DebugApp debugApp, params DebugProduct[] debugProducts)
        {
            XElement listingInfo = new XElement("ListingInformation", new XElement("App",
                new XElement("AppId", debugApp.AppId.ToString()),
                new XElement("LinkUri", debugApp.LinkUri.ToString()),
                new XElement("CurrentMarket", debugApp.CurrentMarket),
                new XElement("AgeRating", debugApp.AgeRating),
                new XElement("MarketData",
                    new XAttribute(XNamespace.Xml + "lang", debugApp.CurrentMarket.ToLower()),
                    new XElement("Name", debugApp.Name),
                    new XElement("Description", debugApp.Description),
                    new XElement("Price", debugApp.Price.ToString("F2")),
                    new XElement("CurrencySymbol", debugApp.CurrencySymbol),
                    new XElement("CurrencyCode", debugApp.CurrencyCode))));

            XElement licenseInfo = new XElement("LicenseInformation",
                new XElement("App",
                  new XElement("IsActive", debugApp.IsActive),
                  new XElement("IsTrial", debugApp.IsTrial)));

            foreach (DebugProduct debugProduct in debugProducts)
            {
                listingInfo.Add(new XElement("Product",
                        new XAttribute("ProductId", debugProduct.ProductId),
                        new XElement("MarketData",
                            new XAttribute(XNamespace.Xml + "lang", debugApp.CurrentMarket.ToLower()),
                            new XElement("Name", debugProduct.Name),
                            new XElement("Price", debugProduct.Price.ToString("F2")),
                            new XElement("CurrencySymbol", debugProduct.CurrencySymbol),
                            new XElement("CurrencyCode", debugProduct.CurrencyCode))));

                licenseInfo.Add(new XElement(new XElement("Product",
                    new XAttribute("ProductId", debugProduct.ProductId),
                    new XElement("IsActive", debugProduct.IsActive))));
            }

            return new XElement("CurrentApp", listingInfo, licenseInfo);
        }

        protected async static void WriteWindowsStoreProxyFileAsync(string windowsStoreProxy)
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

        protected async static void GetFullAppInfoAsync(FullAppInfoHandler fullAppInfoCallback, bool isDebug)
        {
            ListingInformation listing;
            if (isDebug)
            {
                listing = await CurrentAppSimulator.LoadListingInformationAsync();
            }
            else
            {
                listing = await CurrentAppSimulator.LoadListingInformationAsync();
            }
            FullAppInfo appInfo = GetAppInfoFromListing(listing);
            fullAppInfoCallback(appInfo);
        }

        protected async static void GetProductInfoAsync(string productName, ProductInfoHandler productInfoCallback, bool isDebug)
        {
            ListingInformation listing;
            if (isDebug)
            {
                listing = await CurrentAppSimulator.LoadListingInformationAsync();
            }
            else
            {
                listing = await CurrentAppSimulator.LoadListingInformationAsync();
            }
            ProductListing product = listing.ProductListings[productName];
            ProductInfo productInfo = GetProductInfoFromProduct(product);
            productInfoCallback(productInfo);
        }

        protected static FullAppInfo GetAppInfoFromListing(ListingInformation listing)
        {
            FullAppInfo appInfo = null;

            if (listing != null)
            {
                appInfo = new FullAppInfo();
                appInfo.Name = listing.Name;
                appInfo.Description = listing.Description;
                appInfo.Market = listing.CurrentMarket;
                appInfo.AgeRating = listing.AgeRating;
                appInfo.Price = listing.FormattedPrice;
            }
            return appInfo;
        }

        protected static ProductInfo GetProductInfoFromProduct(ProductListing listing)
        {
            ProductInfo productInfo = null;

            if (listing != null)
            {
                productInfo = new ProductInfo();
                productInfo.Name = listing.Name;
                productInfo.Id = listing.ProductId;
                productInfo.Price = listing.FormattedPrice;
            }
            return productInfo;
        }

        protected async static void PurchaseFullAppAsync(PurchaseResultHandler purchaseCallback, bool isDebug)
        {
            if (!IsFullAppActive(isDebug))
            {
                try
                {
                    if (isDebug)
                    {
                        await CurrentAppSimulator.RequestAppPurchaseAsync(false);
                    }
                    else
                    {
                        await CurrentApp.RequestAppPurchaseAsync(false);
                    }
                    PurchaseResult purchaseResult = IsFullAppActive(isDebug) ? PurchaseResult.PurchaseSuccess : PurchaseResult.PurchaseCancel;
                    purchaseCallback(purchaseResult);
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
        protected async static void PurchaseProductAsync(string productName, PurchaseResultHandler purchaseCallback, bool isDebug)
        {
            if (!IsProductActive(productName, isDebug))
            {
                try
                {
                    if (isDebug)
                    {
                        await CurrentAppSimulator.RequestProductPurchaseAsync(productName, false);
                    }
                    else
                    {
                        await CurrentApp.RequestProductPurchaseAsync(productName, false);
                    }

                    PurchaseResult purchaseResult = IsProductActive(productName, isDebug) ? PurchaseResult.PurchaseSuccess : PurchaseResult.PurchaseCancel;
                    purchaseCallback(purchaseResult);
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
