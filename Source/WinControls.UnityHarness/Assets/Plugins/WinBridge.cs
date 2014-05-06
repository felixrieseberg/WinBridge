using UnityEngine;
using System.Collections;

public class WinBridge : MonoBehaviour {

	// Singleton Management
	private static WinBridge instance;
	private static GameObject container;
	public static WinBridge GetInstance()
	{
		if( !instance )
		{
			container = new GameObject();
			container.name = "WinBridge";
			instance = container.AddComponent(typeof(WinBridge)) as WinBridge;
		}
		return instance;
	}

}
