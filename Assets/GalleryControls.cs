using UnityEngine;
using System.Collections;

public class GalleryControls : MonoBehaviour {

	private GameObject[] objects;
    private Ray ray;
	private RaycastHit[] hits;

	// Use this for initialization
	void Start () {
        objects = GameObject.FindGameObjectsWithTag("target");
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
            }

            Behaviour bt = (Behaviour)hit.collider.GetComponent("Halo");
            bt.enabled = state;
        }
	}
}
