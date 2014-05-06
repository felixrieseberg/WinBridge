---
layout: docs
title: Store.IsFullAppActive Method
prev_section: configuration
next_section: api/store.ctor
permalink: /docs/api/store.isfullappactive/	
---

## Syntax
```csharp
public static bool IsFullAppActive(bool isDebug = false)
```

## Parameters
* _isDebug_
    flag to indicate call should be made using debug Store information. Should be used in conjuction with [EnableDebugWindowsStoreProxy][].

## Return value
_true_  if the application's license is active, _false_ if not.


## Remarks
none.

[EnableDebugWindowsStoreProxy]: {{site.github.url}}/docs/api/store.enabledebugwindowsstoreproxy