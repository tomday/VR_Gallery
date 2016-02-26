using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OrientationControl : MonoBehaviour {

	private string level;

	private bool loaded = false;

	private Ray ray;
	private RaycastHit hit;

	public GameObject levelsHolder;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, this.transform.forward);
		ray = new Ray (this.transform.position, this.transform.forward);

		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast (ray, out hit, 100)) {
				Debug.Log(hit.collider.name); 
				level = hit.collider.name;
			}
		}

		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Moved) {
				Debug.Log (touch.deltaPosition);
				levelsHolder.transform.RotateAround (new Vector3(0, 0, 0), new Vector3(0, 1, 0), (float)(touch.deltaPosition.x * Time.deltaTime));

			}

			if (touch.phase == TouchPhase.Began) {
				if (Physics.Raycast (ray, out hit, 100)) {
					level = hit.collider.name;
				}
			}
		} 

		if (SceneManager.GetActiveScene ().name != level)
			loaded = false;

		if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight) {
			if (!loaded) {
				SceneManager.LoadScene (level);
				loaded = true;
			}
		}

		if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown) {
				SceneManager.LoadScene ("menu");
		}
	}
}
