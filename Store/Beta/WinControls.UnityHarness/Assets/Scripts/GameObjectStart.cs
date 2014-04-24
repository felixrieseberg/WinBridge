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
		WinControls.Store.EnableWindowsStoreProxy("<?xml version=\"1.0\" encoding=\"utf-16\" ?><CurrentApp><ListingInformation><App><AppId>2B14D306-D8F8-4066-A45B-0FB3464C67F2</AppId><LinkUri>http://apps.microsoft.com/webpdp/app/2B14D306-D8F8-4066-A45B-0FB3464C67F2</LinkUri><CurrentMarket>en-US</CurrentMarket><AgeRating>3</AgeRating><MarketData xml:lang=\"en-us\"><Name>Application Link</Name><Description>Application Link</Description><Price>4.99</Price><CurrencySymbol>$</CurrencySymbol><CurrencyCode>USD</CurrencyCode></MarketData></App></ListingInformation><LicenseInformation><App><IsActive>true</IsActive><IsTrial>false</IsTrial></App></LicenseInformation></CurrentApp>", Debug.isDebugBuild);
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
