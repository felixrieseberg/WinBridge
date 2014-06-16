using UnityEngine;
using System.Collections;

// This is only a demo script for WinBridge and can be deleted safely!
public class PlayVideo : MonoBehaviour {

	// Use this for initialization
	void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			Play();
		}
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel(0);
		}
	}

	void Play() {
		// Play video right away. This video will only play if the
		// scene is build and compiled as a WinRT project.
		WinBridge.VideoPlayback.PlayVideo("https://github.com/ProtossEngineering/WinBridge/blob/release/Various/invitation.mp4?raw=true", true, true);
	}
	void OnGUI() {
		GUI.Label(new Rect(10, 10, 700, 80), "Press 1 to immediatly play a video. Press ESC to go back.\n" +
			"Settings: Show controls (true), Skip video on click/tap (true)");
	}

	
}
