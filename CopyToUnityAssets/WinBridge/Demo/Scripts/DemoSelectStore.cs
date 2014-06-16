using UnityEngine;
using System.Collections;

public class DemoSelectStore : MonoBehaviour {

	public GameObject purchaseInAppProduct;
	public GameObject purchaseFullProduct;
	public GameObject requestReview;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			purchaseInAppProduct.GetComponent<StorePurchaseInAppProduct>().BuyProduct();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			requestReview.GetComponent<StoreRequestReview>().RequestReview();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			purchaseFullProduct.GetComponent<StorePurchaseFullVersion>().UpgradeTrial();
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel(0);
		}
	}
	
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 700, 40), "Select your demo: Press 1 to test purchase, 2 to request a review, 3 to upgrade from trial to full version. Press ESC to go back.");
		GUI.Label(new Rect(10, 100, 700, 200), "Please note: This demo scene is mostly a code demo - interaction with the Windows Store doesn't become really interesting until your app is in the Windows Store. The features presented here will however work if compiled as a Windows Store app with Visual Studio.\n\n" +
			"In this demo, either the In-App-Purchase or the Trial Upgrade demo will work, depending on whether or not the license simulator has been set to simulate trial mode or not. \n\n" +
			"You can change that setting in the Unity Editor - please see the GameObject 'Store Debug Info' in this demo scene." );
	}
}
