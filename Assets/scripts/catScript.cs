using UnityEngine;
using System.Collections;

public class catScript : MonoBehaviour {

	public Transform mouse;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (mouse == null) {
			//will stop calling FixedUpdate function right away
			return;
		}
			
		//calculates a vector from the cat to the mouse
		Vector3 directionToMouse = mouse.position - transform.position;


		//check if the mouse is in front of the cat
		if (Vector3.Angle (transform.position, directionToMouse) < 180) {

			Ray catRay = new Ray (transform.position, directionToMouse);
			RaycastHit catRayHitInfo = new RaycastHit ();

			if (Physics.Raycast (catRay, out catRayHitInfo, 5f)) {
				if (catRayHitInfo.collider.tag == "mouse") {
					if (catRayHitInfo.distance <= 1) {
						Destroy (mouse.gameObject);
					} else {
						GetComponent<Rigidbody> ().AddForce (directionToMouse.normalized * 1000f);
					}
				}
			}

		}
	
	}
}
