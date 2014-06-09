WinBridge: WinRT Controls & Features for Unity3D
////////////////////////////////////////////////////////////////////////////////////////
----------------------------------------------------------------------------------------
The WinBridge is a plugin for Unity3D that enables easier command of native controls and 
features of WinRT (the underlying library behind Windows Store, Windows Phone and Xbox 
One apps). Currently implemented:

- Windows Store (In-App-Purchases, Trial Upgrade, Reciept management)
- Native Message Dialogs
- Native Video Playback

Usage
////////////////////////////////////////////////////////////////////////////////////////
----------------------------------------------------------------------------------------

Windows Store
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
This class manages full interaction with the Windows Store. To enable the functionality 
of all these methods during debug mode, please see the next point (Windows Store Proxy).

Purchasing full version of the app
----------------------------------------------------------------------------------------
WinBridge.PurchaseFullApp(WinControls.Store.PurchaseResultHandler handler)

- handler: The method that is used as a callback.

Checking if a valid license is present
----------------------------------------------------------------------------------------
WinBridge.IsFullAppActive()

Getting full app informtion reciept
----------------------------------------------------------------------------------------
WinBridge.GetFullAppInfo(WinControls.Store.FullAppInfoHandler handler)

- handler: The method that is used as a callback.

Purchasing a product (In-App-Purchase)
----------------------------------------------------------------------------------------
WinBridge.PurchaseProduct(string productId, WinControls.Store.PurchaseResultHandler 
handler)

- productId: The id of the product that is to be bought. Please note that this is only 
invoking the purchase UI - the user has to actually confirm the purchase.
- handler: The method that is used as a callback. The passed PurchaseResult indicates 
whether or not the transaction was completed.

Getting product information (name, price, description) (In-App-Purchase)
----------------------------------------------------------------------------------------
WinBridge.GetProductInfo(string productId, WinControls.Store.ProductInfoHandler handler)

- productId: The id of the product. 
- handler: The method that is used as a callback. 

Requesting a review of the app
----------------------------------------------------------------------------------------
WinBridge.RequestReview(string label, string okLabel, string cancelLabel)

- label: The label of the message box (default: "Would you like to rate and review this 
app?")
- okLabel: The label of the OK button (default: "Rate and Review")
- cancelLabel: The label of the cancel button (default: "Not now)

Windows Store Proxy
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
A Windows Store Proxy can be attached to any GameObject with _Add Component - WinBridge 
- Windows Store Proxy_. The inspector editor is fairly self-explanatory - for questions 
around the purpose of individual fields, please consult the official Windows Store 
documentation on MSDN (http://msdn.microsoft.com/en-us/library/windows/apps/
windows.applicationmodel.store.currentappsimulator).

If you know what you're doing, hate convenience and you feel like providing a full 
WindowsStoreProxy.xml straight to the plugin, call:

WinControls.Store.EnableDebugWindowsStoreProxy(string WindowsStoreProxyXML);


Message Box
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
The MessageBox can be added to any GameObject with _Add Component - WinBridge - 
MessageBox_. Simply make all your settings in the inspector window. To invoke the message 
box, call Show() on that component.

Play Fullscreen Video
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

WinBridge.VideoPlayback.PlayVideoFullscreen(string videoUrl, bool controlsEnabled, bool 
tapSkipsVideo)

- videoUrl: The URL to the video as a string, including official qualifier (for instance 
ms-appx:/// for an asset inside the app package or http:// for a web resource). _Note: 
If the video should ship with the app package, it is best placed inside the appx package 
using Visual Studio_.
- controlsEnabled (default: _true_): _true_ enables the native video controls (scrubber, 
play/pause, etc.), _false_ disables them. 
- tapSkipsVideo (default: _false_): _true_ automatically removes the video element if 
the user taps/clicks it, _false_ doesn't. If controlsEnabled is set to _true_ and 
tapSkipsVideo is set to _false_, a tap/click will pause the video.

License
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
This repository is open-source and currently maintained by a small group of Microsoft 
developer evangelists. It should be noted that this plugin is provided as-is with no 
warranties given. It is released under the MS-LPL license. For details, please see 
the attached license.txt (MS-LPL) or http://clrinterop.codeplex.com/license.