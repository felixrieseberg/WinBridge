using UnityEngine;
using System.Collections;
using WinControls;

public class GameObjectStart : MonoBehaviour {

	public string windowsStoreProxyXML = "<?xml version=\"1.0\" encoding=\"utf-16\" ?><CurrentApp><ListingInformation><App><AppId>2B14D306-D8F8-4066-A45B-0FB3464C67F2</AppId><LinkUri>http://apps.microsoft.com/webpdp/app/2B14D306-D8F8-4066-A45B-0FB3464C67F2</LinkUri><CurrentMarket>en-US</CurrentMarket><AgeRating>3</AgeRating><MarketData xml:lang=\"en-us\"><Name>Application Link</Name><Description>Application Link</Description><Price>4.99</Price><CurrencySymbol>$</CurrencySymbol><CurrencyCode>USD</CurrencyCode></MarketData></App></ListingInformation><LicenseInformation><App><IsActive>true</IsActive><IsTrial>false</IsTrial></App></LicenseInformation></CurrentApp>";

	void Start () {
		var messageBox = new WinControls.MessageBox ();
		var trialUpgradeButton = new WinControls.MessageBox.Command ("Trial Upgrade", trialUpgrade);
		var productPurchaseButton = new WinControls.MessageBox.Command ("In app purchase", productPurchase);
		messageBox.ShowMessageBox ("Which scenario would you like to test?", "Store plugin test", trialUpgradeButton, productPurchaseButton);
	
		// Initialize the Store proxy on debug builds
		WinControls.Store.EnableWindowsStoreProxy(windowsStoreProxyXML, Debug.isDebugBuild);

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
