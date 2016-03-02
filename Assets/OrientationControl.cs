using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OrientationControl : MonoBehaviour {

	private string level = "Menu";

	private bool loaded = false;

	private bool isLandscape = false, isPortrait = true;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frameDo you still have that double sided sticky taop
	void Update () {

		isLandscape = (Input.deviceOrientation == DeviceOrientation.LandscapeLeft);
		if (isLandscape)
			Debug.Log ("Landscape");
		isPortrait = (Input.deviceOrientation == DeviceOrientation.Portrait);
		if (isPortrait)
			Debug.Log ("Portrait");

		//Debug.Log (SceneManager.GetActiveScene ().name);

		if (isLandscape && SceneManager.GetActiveScene().name == "Menu") {
			SceneManager.LoadSceneAsync (level);
		}
		if (isPortrait && SceneManager.GetActiveScene().name != "Menu") {
			SceneManager.LoadSceneAsync ("Menu");
			level = "Menu";
		}
	}

	public void setLevel(string name){
		level = name;
		Debug.Log("Selected Level: " + level);
	}
}
