using UnityEngine;
using System.Collections;
using WinControls;

public class GameObjectStart : MonoBehaviour {


	// Use this for initialization
	void Start () {
		var messageBox = new WinControls.MessageBox ();
		var yesButton = new WinControls.MessageBox.Command ("Yes", YesAction);
		var noButton = new WinControls.MessageBox.Command ("No", NoAction);
		messageBox.ShowMessageBox ("Test in app purchase with debug?", "Test dialog", yesButton, noButton);
	}

	void YesAction(object UICommand) {
		Debug.LogError("Yes button clicked");
		WinControls.Store.PurchaseFullApp (handlePurchase, true);
	}
	
	void NoAction(object UICommand) {
		// **** Sample snips ***//
		//
		//bool isFullAppActive = WinControls.Store.IsFullAppActive(true);
		//bool isProductActive = WinControls.Store.IsProductActive("bigsword");
		//WinControls.Store.PurchaseProduct ("bigsword", handlePurchase);

		Debug.LogError("No button clicked");
		WinControls.Store.PurchaseFullApp (handlePurchase);

	}

	void handlePurchase(Store.PurchaseResult result) {
		Debug.LogError ("Purchase result " + result);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
