---
layout: docs
title: Store Class
prev_section: configuration
next_section: api/store.ctor
permalink: /docs/api/store/	
---

Defines methods and properties you can use to get license and listing info about the current app and perform in-app purchases.

    Note:  This object obtains its data from the Windows Store, so you must 
    have a Windows Store developer account and the app must be published 
    in the Windows Store. If you don't have a Windows Store developer account, 
    you can test the functions of this class by using the debug parameter 
    in each method.

## Methods 

<span class="header type_column"></span><span class="header name_column">Name</span><span class="header description_column">Description</span><br>
<span class="type_column">static</span><span class="name_column">[PurchaseFullApp][]</span><span class="description_column">Performs the operation to enable the user to buy a full license for the current app.</span><br>
<span class="type_column">static</span><span class="name_column">[IsFullAppActive][]</span><span class="description_column">Gets the value that indicates whether the license is active.</span><br>
<span class="type_column">static</span><span class="name_column">[GetFullAppInfo][]</span><span class="description_column">Loads the app's listing information.
The returned [FullAppInfo][] object contains listing information (e.g. name, price, age rating) specific to the market the user currently resides in. To get listing information for products available via in-app purchases use [GetProductInfo][].</span><br>
<span class="type_column">static</span><span class="name_column">[PurchaseProduct][]</span><span class="description_column">Performs the operation that displays the UI that is used to simulate an in-app purchase of content or a feature from the Windows Store.</span><br>
<span class="type_column">static</span><span class="name_column">[IsProductActive][]</span><span class="description_column">Gets the value that indicates whether the in-app product license is active.</span><br>
<span class="type_column">static</span><span class="name_column">[GetProductInfo][]</span><span class="description_column">Loads the in-app product's listing information.</span><br>
<span class="type_column">static</span><span class="name_column">[EnableDebugWindowsStoreProxy][]</span><span class="description_column"><br>Creates a WindowsStoreProxy.xml file for use during debugging or before your app is published.</span><br>

[PurchaseFullApp]: {{site.github.url}}/docs/store.purchasefullapp
[IsFullAppActive]: {{site.github.url}}/docs/store.isfullappactive
[GetFullAppInfo]: {{site.github.url}}/docs/store.getfullappinfo
[PurchaseProduct]: {{site.github.url}}/docs/store.purchaseproduct
[IsProductActive]: {{site.github.url}}/docs/store.isproductactive
[GetProductInfo]: {{site.github.url}}/docs/store.getproductinfo
[EnableDebugWindowsStoreProxy]: {{site.github.url}}/docs/store.enabledebugwindowsstoreproxy
[FullAppInfo]: {{site.github.url}}/docs/store.fullappinfo