using UnityEngine;
using System.Collections;

public class OrientationControl : MonoBehaviour {

	private string level = "";

	private Ray ray;
	private RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (this.transform.position, this.transform.forward);
		ray = new Ray (this.transform.position, this.transform.forward);

		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			if (touch.phase == TouchPhase.Moved) {
				Debug.Log (touch.deltaPosition);
			}

			if (touch.phase == TouchPhase.Began) {
				if (Physics.Raycast (ray, out hit, 100)) {
					level = hit.collider.name;
				}
			}
		} 

		if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight) {

		}

		if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown) {

		}
	}
}
