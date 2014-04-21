using UnityEngine;
using System.Collections;
using WinControls;

public class GameObjectStart : MonoBehaviour {
	WinControls.MessageBox.CommandHandlerDelegate yesDelegate;
	WinControls.MessageBox.CommandHandlerDelegate noDelegate;

	// Use this for initialization
	void Start () {
		yesDelegate = YesAction;
		noDelegate = NoAction;

		var messageBox = new WinControls.MessageBox ();
		var yesButton = new WinControls.MessageBox.Command ("Yes", yesDelegate);
		var noButton = new WinControls.MessageBox.Command ("No", noDelegate);
		messageBox.ShowMessageBox ("Test in app purchase with debug?", "Test dialog", yesButton, noButton);
	}

	void YesAction(object UICommand) {
		//WinControls.Store.PurchaseFullApp (true);
		//bool isFullAppActive = WinControls.Store.IsFullAppActive(true);
		WinControls.Store.PurchaseProduct ("bigsword", true);
		Debug.LogError(WinControls.Store.IsProductActive("bigsword", true));
		Debug.LogError("no clicked c#");
	}
	
	void NoAction(object UICommand) {
		//WinControls.Store.PurchaseFullApp ();
		//bool isFullAppActive = WinControls.Store.IsFullAppActive();
		WinControls.Store.PurchaseProduct ("bigsword");
		Debug.LogError(WinControls.Store.IsProductActive("bigsword"));
		Debug.LogError("yes clicked c#");

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
