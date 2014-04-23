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
#endif

#if WINDOWS_PHONE

#endif

namespace WinControls
{
    public class MessageBox
    {
        public delegate void CommandHandlerDelegate(object UICommand);

        public class Command
        {
            public string text;
            public CommandHandlerDelegate action;

            public Command(string text, CommandHandlerDelegate action)
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

        public static void PurchaseFullApp()
        {
            PurchaseFullApp(false);
        }
        public static void PurchaseFullApp(bool isDebug)
        {
#if NETFX_CORE
            CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    if (isDebug)
                    {
                        CurrentAppSimulator.RequestAppPurchaseAsync(false);
                    }
                    else
                    {
                        CurrentApp.RequestAppPurchaseAsync(false);
                    }
                });
#endif
        }

    }
}
