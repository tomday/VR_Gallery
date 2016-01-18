using UnityEngine;
using System.Collections;

public class GalleryControls : MonoBehaviour {

	private GameObject[] objects;
	private GameObject cObj;

    private Ray ray;
	private RaycastHit[] hits;

	private CardboardHead head;

	private float time = 0, speed = 10;

	private bool timing = false, moving = false;

	// Use this for initialization
	void Start () {
        objects = GameObject.FindGameObjectsWithTag("target");
		head = this.GetComponent<CardboardHead> ();
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
                state = true;
				cObj = hit.collider.gameObject;
            }

            Behaviour bt = (Behaviour)hit.collider.GetComponent("Halo");
            bt.enabled = state;
        }

		if (timing) {
			time += Time.deltaTime;
			Debug.Log ("Current Time: " + time);
		}

		if (time > 2.0f) {
			moving = true;
			stopTimer ();
		}

		if (moving) {
			Debug.Log ("Moving");
			float step = speed * Time.deltaTime;

			//head.target = cObj.transform;
			Vector3 temp = Vector3.MoveTowards(this.transform.position, cObj.transform.position, step);
			Debug.Log (temp);

			if (Vector3.Distance (this.transform.position, cObj.transform.position) < 2)
				head.target = null;
				moving = false;
		}
	}

	public void startTimer () {
		Debug.Log ("Timer Started");
		timing = true;
	}
	public void stopTimer() {
		Debug.Log ("Timer Stopped");
		timing = false;
		time = 0;
	}
}
