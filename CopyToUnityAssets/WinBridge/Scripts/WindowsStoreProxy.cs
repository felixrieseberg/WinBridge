using UnityEngine;
using System.Collections;
using WinControls;
using System;
using System.Collections.Generic;


[AddComponentMenu("WinBridge/Windows Store Proxy")]

[ExecuteInEditMode]
public class WindowsStoreProxy : MonoBehaviour
{
    private Store.DebugApp _debugApp;

    // This field can't be serialized :(
    private List<Store.DebugProduct> processedDebugProducts = new List<Store.DebugProduct>();
    [SerializeField]
    public List<SerializableDebugProduct> debugProducts = new List<SerializableDebugProduct>();

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

    private static WindowsStoreProxy instance;
    private static GameObject container;
    public static WindowsStoreProxy GetInstance()
    {
        if (!instance)
        {
            container = new GameObject();
            container.name = "WindowsStoreProxy";
            instance = container.AddComponent(typeof(WindowsStoreProxy)) as WindowsStoreProxy;
        }
        return instance;
    }

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

        foreach (SerializableDebugProduct preProduct in debugProducts)
        {
            WinControls.Store.DebugProduct debugProduct = new WinControls.Store.DebugProduct();
            debugProduct.CurrencyCode = preProduct.currencyCode;
            debugProduct.CurrencySymbol = preProduct.currencySymbol;
            debugProduct.IsActive = preProduct.disActive;
            debugProduct.Name = preProduct.productName;
            debugProduct.Price = preProduct.price;
            debugProduct.ProductId = preProduct.productId;

            processedDebugProducts.Add(debugProduct);
        }

        Store.EnableDebugWindowsStoreProxy(_debugApp, processedDebugProducts.ToArray());
		Debug.Log("Windows Store Proxy: Adding products: " + processedDebugProducts.ToArray().Length);

	}

    [Serializable]
    public class SerializableDebugProduct {

        public string productId;
        public string productName;
        public double price;
        public string currencySymbol;
        public string currencyCode;
        public bool disActive;

        public SerializableDebugProduct() { }

        public SerializableDebugProduct(string productId, string productName, double price, string currencySymbol, string currencyCode, bool isActive)
        {
            this.productId = productId;
            this.productName = productName;
            this.price = price;
            this.currencyCode = currencyCode;
            this.currencySymbol = currencySymbol;
            this.disActive = isActive;
        }
    }

    /// <summary>
    /// Add a debug product.
    /// </summary>
    public void AddDebugProduct(string productId, string productName, double? price, string currencySymbol, string currencyCode, bool? isActive)
    {
        Debug.Log("Added product");
        SerializableDebugProduct _thisProduct = new SerializableDebugProduct();

        if (!string.IsNullOrEmpty(productId)) { _thisProduct.productId = productId; };
        if (!string.IsNullOrEmpty(productName)) { _thisProduct.productName = productName; };
        if (price != null) { _thisProduct.price = Convert.ToDouble(price); };
        if (!string.IsNullOrEmpty(currencySymbol)) { _thisProduct.currencySymbol = currencySymbol; };
        if (!string.IsNullOrEmpty(currencyCode)) { _thisProduct.currencyCode = currencyCode; };
        if (isActive != null) { _thisProduct.disActive = Convert.ToBoolean(isActive); };

        debugProducts.Add(_thisProduct);
    }
	
}
