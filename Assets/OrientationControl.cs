using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class OrientationControl : MonoBehaviour {

	private string level = "Menu";

	public GameObject levels;
	public GameObject levelLoader;

	//private bool loaded = false;

	private bool isLandscape = false, isPortrait = true;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {

		if (SceneManager.GetActiveScene ().name == "Menu")
			levelLoader.GetComponentInChildren<Text>().text = "Load " + level;

		isLandscape = (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight);
		//if (isLandscape)
		//	Debug.Log ("Landscape");
		isPortrait = (Input.deviceOrientation == DeviceOrientation.Portrait);
		//if (isPortrait)
		//	Debug.Log ("Portrait");

		//Debug.Log (SceneManager.GetActiveScene ().name);

		if (isLandscape && SceneManager.GetActiveScene().name == "Menu") {
			levels.SetActive (false);
			levelLoader.SetActive (true);
		}
		if (isPortrait && SceneManager.GetActiveScene ().name == "Menu") {
			levels.SetActive (true);
			levelLoader.SetActive (false);
		}
		if (isPortrait && SceneManager.GetActiveScene().name != "Menu") {
			level = "Menu";
			loadLevel ();
		}
	}

	public void setLevel(string name){
		level = name;
		Debug.Log("Selected Level: " + level);
	}

	public void loadLevel(){
		SceneManager.LoadScene (level);
		Debug.Log (level + " loaded");
	}
}
