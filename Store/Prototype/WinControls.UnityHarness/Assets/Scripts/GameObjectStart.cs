using UnityEngine;
using System.Collections;
using WinControls;

public class GameObjectStart : MonoBehaviour {
	WinControls.MessageBox.CommandHandlerDelegate purchaseDelegate;
	WinControls.MessageBox.CommandHandlerDelegate adsDelegate;

	// Use this for initialization
	void Start () {
		purchaseDelegate = PurchaseAction;
		adsDelegate = AdsAction;

		var messageBox = new WinControls.MessageBox ();
		var purchaseButton = new WinControls.MessageBox.Command ("Purchase", purchaseDelegate);
		var adsButton = new WinControls.MessageBox.Command ("Continue with ads", adsDelegate);
		messageBox.ShowMessageBox ("Please select an option to continue playing", "Trial expired", purchaseButton, adsButton);
	}

	void PurchaseAction(object UICommand) {
		WinControls.Store.PurchaseFullApp ();
	}
	
	void AdsAction(object UICommand) {
		Debug.LogError("Ads clicked c#");
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
