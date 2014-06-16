using UnityEngine;
using System.Collections;
using WinControls;

// This is only a demo script for WinBridge and can be deleted safely!
public class StorePurchaseFullVersion : MonoBehaviour {

	// Update is called once per frame
	public void UpgradeTrial () {
		WinBridge.Store.PurchaseFullApp(UpgradeTrialHandler);
	}

	void UpgradeTrialHandler(Store.PurchaseResult result) {
		// Possible results:
		// PurchaseSuccess,
		// PurchaseCancel,
		// PurchaseError,
		// AlreadyPurchased
		Debug.Log(result);
	}

	void GetAppInfo() {
		// Let's retrieve some information about this app
		WinBridge.Store.GetFullAppInfo(GetAppInfoHandler);
	}

	void GetAppInfoHandler(Store.FullAppInfo appInfo) {
		// This is the handler for GetAppInfo()
		Debug.LogError ("App name " +  appInfo.Name);
		Debug.LogError ("App price " +  appInfo.Price);
		Debug.LogError ("Is app active? " + Store.IsFullAppActive (Debug.isDebugBuild));
	}

}
