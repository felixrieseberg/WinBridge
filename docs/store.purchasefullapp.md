---
layout: docs
title: Store.PurchaseFullApp Method
prev_section: configuration
next_section: api/store.ctor
permalink: /docs/api/store.purchasefullapp/	
---

## Syntax
```csharp
public static void PurchaseFullApp(PurchaseResultHandler purchaseCallback, bool isDebug = false)
```

## Parameters
* _purchaseCallback_
	a [PurchaseResultHandler][] delegate used to process the result.

* _isDebug_
    flag to indicate call should be made using debug Store information. Should be used in conjuction with [EnableDebugWindowsStoreProxy][].

## Return value
none.

## Remarks
none.

[PurchaseResultHandler]: {{site.github.url}}/docs/api/store.purchaseresulthandler
[EnableDebugWindowsStoreProxy]: {{site.github.url}}/docs/api/store.enabledebugwindowsstoreproxy