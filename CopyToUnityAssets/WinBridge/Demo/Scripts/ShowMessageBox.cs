using UnityEngine;
using System.Collections;

// This is only a demo script for WinBridge and can be deleted safely!
public class ShowMessageBox : MonoBehaviour {

	// Use this for initialization
	void Update () {
		// Show MessageBox right away. It will only show
		// scene is build and compiled as a WinRT project.
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			gameObject.GetComponent<WBMessageDialog>().Show();
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel(0);
		}
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 700, 40), "Press 1 to show the MessageBox. Press ESC to go back.");
	}

}
