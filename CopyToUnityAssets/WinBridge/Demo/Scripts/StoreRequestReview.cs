using UnityEngine;
using System.Collections;

public class StoreRequestReview : MonoBehaviour {
	
	public void RequestReview() {
		// This immediatly asks the user if he wants to review the app.
		// If the user confirms, the appropriate Windows Store UI will
		// be opened.
		WinBridge.Store.RequestReview();
	}
}
