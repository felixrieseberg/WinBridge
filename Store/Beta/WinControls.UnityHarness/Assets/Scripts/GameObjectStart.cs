using UnityEngine;
using System.Collections;
using WinControls;

public class GameObjectStart : MonoBehaviour {

	void Start () {
		var messageBox = new MessageBox ();
		var trialUpgradeButton = new MessageBox.Command ("Trial Upgrade", trialUpgrade);
		var productPurchaseButton = new MessageBox.Command ("In app purchase", productPurchase);
		messageBox.ShowMessageBox ("Which scenario would you like to test?", "Store plugin test", trialUpgradeButton, productPurchaseButton);
	
		// Initialize the Store proxy on debug builds
		Store.EnableDebugWindowsStoreProxy("<?xml version=\"1.0\" encoding=\"utf-16\" ?><CurrentApp><ListingInformation><App><AppId>2B14D306-D8F8-4066-A45B-0FB3464C67F2</AppId><LinkUri>http://apps.microsoft.com/webpdp/app/2B14D306-D8F8-4066-A45B-0FB3464C67F2</LinkUri><CurrentMarket>en-US</CurrentMarket><AgeRating>3</AgeRating><MarketData xml:lang=\"en-us\" ><Name>WinControls Test app</Name><Description>Application Link</Description><Price>4.99</Price><CurrencySymbol>$</CurrencySymbol><CurrencyCode>USD</CurrencyCode></MarketData></App><Product ProductId=\"bigsword\" ><MarketData xml:lang=\"en-us\" ><Name>Really big sword</Name><Price>50.99</Price><CurrencySymbol>$</CurrencySymbol><CurrencyCode>USD</CurrencyCode></MarketData></Product></ListingInformation><LicenseInformation><App><IsActive>false</IsActive><IsTrial>true</IsTrial></App><Product ProductId=\"bigsword\" ><IsActive>false</IsActive></Product></LicenseInformation></CurrentApp>", handleLicenseChanged);
	}

	void trialUpgrade(object UICommand) {
		Debug.LogError("Trial upgrade button clicked");
		Store.PurchaseFullApp (handlePurchase, Debug.isDebugBuild );
	}
	
	void productPurchase(object UICommand) {
		// Note: Full app must be active for in app product purchase to succeed
		Debug.LogError("In app purchase button clicked");
		Store.PurchaseFullApp (initiateProductPurchase, Debug.isDebugBuild );
	}

	void handleLicenseChanged() {
		Debug.LogError ("License changed");
		Store.GetFullAppInfo (handleAppInfo, Debug.isDebugBuild);
		Store.GetProductInfo ("bigsword", handleProductInfo, Debug.isDebugBuild);
	}
	
	void initiateProductPurchase(Store.PurchaseResult result) {
		Store.PurchaseProduct ("bigsword", handlePurchase, Debug.isDebugBuild );	
	}

	void handlePurchase(Store.PurchaseResult result) {
		Debug.LogError ("Purchase result " + result);
	}

	void handleAppInfo(Store.FullAppInfo info) {
		Debug.LogError ("App name " +  info.Name);
		Debug.LogError ("App price " +  info.Price);
		Debug.LogError ("Is app active? " + Store.IsFullAppActive (Debug.isDebugBuild));
	}

	void handleProductInfo(Store.ProductInfo info) {
		Debug.LogError ("Product name " +  info.Name);
		Debug.LogError ("Product price " +  info.Price);
		Debug.LogError ("Is " + info.Name + " product active? " + Store.IsProductActive (info.Id, Debug.isDebugBuild));
	}

	// Update is called once per frame
	void Update () {

	}
}
