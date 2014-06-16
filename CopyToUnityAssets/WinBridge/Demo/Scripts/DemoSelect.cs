using UnityEngine;
using System.Collections;

public class DemoSelect : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			Application.LoadLevel(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			Application.LoadLevel(2);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			Application.LoadLevel(3);
		}
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 700, 40), "Select your demo: Press 1 for the MessageBox, 2 for Video Playback, 3 for the Windows Store demo.");
	}
}
