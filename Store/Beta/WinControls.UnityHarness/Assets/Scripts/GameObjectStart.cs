using UnityEngine;
using System.Collections;
using WinControls;

public class GameObjectStart : MonoBehaviour {


	// Use this for initialization
	void Start () {
		var messageBox = new WinControls.MessageBox ();
		var trialUpgradeButton = new WinControls.MessageBox.Command ("Trial Upgrade", trialUpgrade);
		var productPurchaseButton = new WinControls.MessageBox.Command ("In app purchase", productPurchase);
		messageBox.ShowMessageBox ("Which scenario would you like to test?", "Store plugin test", trialUpgradeButton, productPurchaseButton);
	
		Debug.LogError("Is full product active? " + WinControls.Store.IsFullAppActive(Debug.isDebugBuild));
		Debug.LogError("Is 'bigsword' product active? " + WinControls.Store.IsProductActive("bigsword", Debug.isDebugBuild));
	}

	void trialUpgrade(object UICommand) {
		Debug.LogError("Trial upgrade button clicked");
		WinControls.Store.PurchaseFullApp (handlePurchase, Debug.isDebugBuild );
	}
	
	void productPurchase(object UICommand) {
		Debug.LogError("In app purchase button clicked");
		WinControls.Store.PurchaseProduct ("bigsword", handlePurchase, Debug.isDebugBuild );	
	}

	void handlePurchase(Store.PurchaseResult result) {
		Debug.LogError ("Purchase result " + result);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
