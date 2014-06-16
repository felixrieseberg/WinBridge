using UnityEngine;
using System.Collections;
using WinControls;

public class StorePurchaseInAppProduct : MonoBehaviour {
	
	public void BuyProduct() {
		// Note: Full app must be active for in app product purchase to succeed
		// If there is a trial, it must be upgraded first
		//WinBridge.Store.PurchaseProduct("myProduct", BuyProductHandler);
		WinBridge.Store.PurchaseProduct("myProduct", BuyProductHandler);
	}

	void BuyProductHandler(Store.PurchaseResult result) {
		// This is the handler for BuyProduct()
		// Possible results:
		// PurchaseSuccess,
		// PurchaseCancel,
		// PurchaseError,
		// AlreadyPurchased
		Debug.Log(result);
	}

	void GetProductInfo() {
		// Let's retrieve information about one of our IAP products
		WinBridge.Store.GetProductInfo("myProduct", ProductInfoHandler);
	}

	void ProductInfoHandler(Store.ProductInfo productInfo) {
		// This is the handler for GetProductInfo()
		Debug.Log("Product name " +  productInfo.Name);
		Debug.Log("Product price " +  productInfo.Price);
		Debug.Log("Is " + productInfo.Name + " product active? " + Store.IsProductActive(productInfo.Id, Debug.isDebugBuild));
	}

}

