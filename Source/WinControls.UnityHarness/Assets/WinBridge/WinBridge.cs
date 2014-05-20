using UnityEngine;
using System.Collections;

public class WinBridge : MonoBehaviour {

	// Singleton Management
	private static WinBridge instance;
	private static GameObject container;
	public static WinBridge GetInstance()
	{
		if( !instance )
		{
			container = new GameObject();
			container.name = "WinBridge";
			instance = container.AddComponent(typeof(WinBridge)) as WinBridge;
		}
		return instance;
	}

    public class VideoPlayback
    {
        /// <summary>
        /// Plays a video using the native WinRT XAML UI control. The video starts immediately.
        /// </summary>
        /// <param name="videoUrl">URL to the video, using WinRT prefixes (see http://msdn.microsoft.com/en-us/library/windows/apps/jj655406.aspx) </param>
        /// <param name="controlsEnabled">If true, the MediaElement's playback controls will be visible</param>
        /// <param name="tapSkipsVideo">If true, a tap/click will stop the video and remove the MediaElement</param>
        public static void PlayVideo(string videoUrl, bool controlsEnabled, bool tapSkipsVideo)
        {
            #if NETFX_CORE || UNITY_WINRT
            Debug.Log("Playing video via native WinRT control. Url: " + videoUrl + "; Controls Enabled: " + controlsEnabled + "; Tap Skips Video: " + tapSkipsVideo);
            WinControls.VideoPlayback.PlayVideoFullscreen(videoUrl, controlsEnabled, tapSkipsVideo);
            #else
            Debug.Log("Skipping native WinRT video playback - not running on WinRT"); 
            #endif
        }

        /// <summary>
        /// Plays a video using the native WinRT XAML UI control. The video starts immediately.
        /// </summary>
        /// <param name="videoUrl">URL to the video, using WinRT prefixes (see http://msdn.microsoft.com/en-us/library/windows/apps/jj655406.aspx) </param>
        /// <param name="controlsEnabled">If true, the MediaElement's playback controls will be visible</param>
        public static void PlayVideo(string videoUrl, bool controlsEnabled)
        {
            PlayVideo(videoUrl, controlsEnabled, false);
        }

        /// <summary>
        /// Plays a video using the native WinRT XAML UI control. The video starts immediately, with playback controls enabled.
        /// </summary>
        /// <param name="videoUrl"></param>
        public static void PlayVideo(string videoUrl)
        {
            PlayVideo(videoUrl, true, false);
        }
    }

    public class Store
    {

        /// <summary>
        /// If the app is in trial mode, Windows ask the user for a purchase of the full version. 
        /// </summary>
        /// <param name="handler">Callback method</param>
        public static void PurchaseFullApp(WinControls.Store.PurchaseResultHandler handler)
        {
            Debug.Log("Attempting to buy full app.");
            WinControls.Store.PurchaseFullApp(handler, Debug.isDebugBuild);
        }

        /// <summary>
        /// Returns true if the app is running in full version.
        /// </summary>
        /// <returns>True if license is valid, false if it is not.</returns>
        public static bool IsFullAppActive()
        {
            if (WinControls.Store.IsFullAppActive(Debug.isDebugBuild))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Loads the app’s listing information. The returned FullAppInfo object contains listing information (e.g. name, price, age rating) specific to the market the user currently resides in.
        /// </summary>
        /// <param name="handler">Callback method</param>
        public static void GetFullAppInfo(WinControls.Store.FullAppInfoHandler handler)
        {
            WinControls.Store.GetFullAppInfo(handler, Debug.isDebugBuild);
        }

        /// <summary>
        /// Activates the UI operation that is used to process an in-app purchase of content or a feature from the Windows Store.
        /// </summary>
        /// <param name="productID">The ID of the product to be purchased</param>
        /// <param name="handler">Callback method (recieving a member of WinControls.Store.PurchaseResult)</param>
        public static void PurchaseProduct(string productId, WinControls.Store.PurchaseResultHandler handler)
        {
            WinControls.Store.PurchaseProduct(productId, handler, Debug.isDebugBuild);
        }

        /// <summary>
        /// Get's information about an In-App-Purchase-Product
        /// </summary>
        /// <param name="productId">ID of the Product</param>
        /// <param name="handler">Callback method (recieving a WinControls.Store.ProductInfo object)</param>
        public static void GetProductInfo(string productId, WinControls.Store.ProductInfoHandler handler)
        {
            WinControls.Store.GetProductInfo(productId, handler, Debug.isDebugBuild);
        }

        /// <summary>
        /// Opens up a message dialog that opens up the Windows Store review page for the current app if the user confirms.
        /// </summary>
        public static void RequestReview()
        {
            RequestReview("Would you like to rate and review this app?", "Rate & Review", "Not now");
        }

        /// <summary>
        /// Opens up a message dialog that opens up the Windows Store review page for the current app if the user confirms.
        /// </summary>
        /// <param name="label">The label of the message box</param>
        public static void RequestReview(string label)
        {
            RequestReview(label, "Rate and Review", "Not now");
        }

        /// <summary>
        /// Opens up a message dialog that opens up the Windows Store review page for the current app if the user confirms.
        /// </summary>
        /// <param name="label">The label of the message box</param>
        /// <param name="okLabel">The label of the OK button</param>
        /// <param name="cancelLabel">Th label of the cancel button</param>
        public static void RequestReview(string label, string okLabel, string cancelLabel)
        {
            WinControls.Store.RequestRating(label, okLabel, cancelLabel);
        }
    }

}
