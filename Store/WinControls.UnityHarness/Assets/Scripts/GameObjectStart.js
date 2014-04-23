#pragma strict

function Start () {

		var messageBox = new WinControls.MessageBox ();
		var purchaseButton = new WinControls.MessageBox.Command ("Purchase", PurchaseAction);
		var adsButton = new WinControls.MessageBox.Command ("Continue with ads", AdsAction);
		messageBox.ShowMessageBox ("Please select an option to continue playing", "Trial expired", purchaseButton, adsButton);
	
	}


	function PurchaseAction() {
		Debug.LogError("Purchase clicked");
	}

	function AdsAction() {
		Debug.LogError("Ads clicked");
	}
function Update () {

}