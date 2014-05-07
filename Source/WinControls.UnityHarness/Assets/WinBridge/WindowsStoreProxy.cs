using UnityEngine;
using System.Collections;
using WinControls;
using System;
using System.Collections.Generic;

[ExecuteInEditMode]
[AddComponentMenu("WinBridge/Windows Store Proxy")]

[System.Serializable]
public class WindowsStoreProxy : MonoBehaviour
{

    private Store.DebugApp _debugApp;
    public List<Store.DebugProduct> debugProducts = new List<Store.DebugProduct>();

    // GUID
    public string appId;
    // URI
    public string linkUri;
    public string currentMarket;
    public int? ageRating;
    public string dName;
    public string description;
    public double price;
    public string currencySymbol;
    public string currencyCode;
    public bool dIsActive = true;
    public bool isTrial = true;

	void Awake () {
        _debugApp = new Store.DebugApp();

        if (!string.IsNullOrEmpty(appId)) { _debugApp.AppId = new Guid(appId); };
        if (!string.IsNullOrEmpty(linkUri)) { _debugApp.LinkUri = new Uri(linkUri); };
        if (ageRating != null) { _debugApp.AgeRating = Convert.ToUInt32(ageRating); };
        if (!string.IsNullOrEmpty(dName)) { _debugApp.Name = dName; };
        if (!string.IsNullOrEmpty(description)) { _debugApp.Description = description; };
        _debugApp.Price = Convert.ToDouble(price);
        if (!string.IsNullOrEmpty(currencySymbol)) { _debugApp.CurrencySymbol = currencySymbol; };
        if (!string.IsNullOrEmpty(currencyCode)) { _debugApp.CurrencyCode = currencyCode; };
        _debugApp.IsActive = dIsActive;
        _debugApp.IsTrial = isTrial;

        Store.EnableDebugWindowsStoreProxy(_debugApp, debugProducts.ToArray());
	}

    public void AddDebugProduct(string productId, string productName, double? price, string currencySymbol, string currencyCode, bool? isActive)
    {
        Store.DebugProduct _thisProduct = new Store.DebugProduct();

        if (!string.IsNullOrEmpty(productId)) { _thisProduct.ProductId = productId; };
        if (!string.IsNullOrEmpty(productName)) { _thisProduct.Name = productName; };
        if (price != null) { _thisProduct.Price = Convert.ToDouble(price); };
        if (!string.IsNullOrEmpty(currencySymbol)) { _thisProduct.CurrencySymbol = currencySymbol; };
        if (!string.IsNullOrEmpty(currencyCode)) { _thisProduct.CurrencyCode = currencyCode; };
        if (isActive != null) { _thisProduct.IsActive = isActive; };

        debugProducts.Add(_thisProduct);
    }
	
}
