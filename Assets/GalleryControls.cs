using UnityEngine;
using System.Collections;

public class GalleryControls : MonoBehaviour {

	private GameObject[] objects;
	private GameObject cObj;
	public GameObject main;
	public Animator CursorAnim;

	private bool play = false;

    private Ray ray;
	private RaycastHit[] hits;

	private float time = 0, speed = 1;

	private bool timing = false, moving = false;

	// Use this for initialization
	void Start () {
        objects = GameObject.FindGameObjectsWithTag("target");

		CursorAnim.Play ("Default");
	}
	
	// Update is called once per frame
	void Update () {
        ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        hits = Physics.RaycastAll(ray);

        foreach (GameObject gobj in objects)
        {
            Behaviour b = (Behaviour)gobj.GetComponent("Halo");
            b.enabled = false;
        }

		foreach (RaycastHit hit in hits){
            if (hit.collider.tag == "target")
            {
				Debug.Log ("Hit Target");
				cObj = hit.collider.gameObject;

				Behaviour bt = (Behaviour)cObj.GetComponent("Halo");
				bt.enabled = true;
            }
        }

		if (timing) {
			time += Time.deltaTime;
		}

		if (time > 2.0f) {
			moving = true;
			stopTimer ();
		}

		if (moving) {
			Debug.Log ("Moving");
			float step = speed * Time.deltaTime;

			//Debug.Log (main.transform.position);
			//Debug.Log (cObj.transform.position);

			Vector3 temp = Vector3.MoveTowards(main.transform.position, cObj.transform.position, step);

			main.transform.position = temp;

			if (Vector3.Distance (main.transform.position, cObj.transform.position) < 2)
				moving = false;
		}
	}

	public void startTimer () {
		//Debug.Log ("Timer Started");

		CursorAnim.Play ("Circle");

		timing = true;
	}
	public void stopTimer() {
		//Debug.Log ("Timer Stopped");

		CursorAnim.Play ("Default");

		timing = false;
		time = 0;
	}
	public void stopMovement(){
		moving = false;
		stopTimer ();
	}
}
