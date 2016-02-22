using UnityEngine;
using System.Collections;

public class GalleryControls : MonoBehaviour {

	private GameObject[] objects;
	private GameObject cObj;
	public GameObject main;
	public Animator cursorAnim;

    private Ray ray;
	private RaycastHit[] hits;

	//private CardboardHead head;

	private float time = 0, speed = 1;

	private bool timing = false, moving = false;

	// Use this for initialization
	void Start () {
        objects = GameObject.FindGameObjectsWithTag("target");
	//	head = this.GetComponent<CardboardHead> ();
	}
	
	// Update is called once per frame
	void Update () {
        ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        //Debug.DrawRay(this.transform.position, this.transform.forward, Color.green);
        hits = Physics.RaycastAll(ray);

        foreach (GameObject gobj in objects)
        {
            Behaviour b = (Behaviour)gobj.GetComponent("Halo");
            b.enabled = false;
        }

		foreach (RaycastHit hit in hits){
            bool state = false;
            if (hit.collider.tag == "target")
            {
				Debug.Log ("Hit Target");
                state = true;
				cObj = hit.collider.gameObject;

				Behaviour bt = (Behaviour)cObj.GetComponent("Halo");
				bt.enabled = state;
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

			Debug.Log (main.transform.position);
			Debug.Log (cObj.transform.position);

			Vector3 temp = Vector3.MoveTowards(main.transform.position, cObj.transform.position, step);

			main.transform.position = temp;

			if (Vector3.Distance (main.transform.position, cObj.transform.position) < 2)
				moving = false;
		}
	}

	public void startTimer () {
		Debug.Log ("Timer Started");
		//Start Animation
		//cursorAnim.StartPlayback();
		timing = true;
	}
	public void stopTimer() {
		Debug.Log ("Timer Stopped");
		//Reset Animation
		//cursorAnim.StopPlayback();
		timing = false;
		time = 0;
	}
	public void stopMovement(){
		moving = false;
		stopTimer ();
	}
}
