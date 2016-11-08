using UnityEngine;
using System.Collections;

public class catScript : MonoBehaviour {
	public AudioSource catChase;
	public AudioSource catWin;
	public Transform mouse;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawRay (transform.position, transform.forward);

		Debug.DrawRay(transform.position, Quaternion.AngleAxis(225, transform.up) * transform.forward, Color.green);
		Debug.DrawRay(transform.position, Quaternion.AngleAxis(135, transform.up) * transform.forward, Color.green);
	}

	void FixedUpdate () {
		if (mouse == null) {
			//will stop calling FixedUpdate function right away
			return;
		}
			
		//calculates a vector from the cat to the mouse
		Vector3 directionToMouse = mouse.position - transform.position;

		//check if the mouse is in front of the cat
		if (Vector3.Angle (transform.position, directionToMouse) < 120) {


			Ray catRay = new Ray (transform.position, directionToMouse);
			RaycastHit catRayHitInfo = new RaycastHit ();
			//Debug.DrawRay (catRay.origin, catRay.direction, Color.grey);

			if (Physics.Raycast (catRay, out catRayHitInfo, 3f)) {
				if (catRayHitInfo.collider.tag == "mouse") {
					if (catRayHitInfo.distance <= 1) {
						Destroy (mouse.gameObject);
					} else {
						if (catChase.isPlaying == false) {
							catChase.Play ();
						}
						GetComponent<Rigidbody> ().AddForce (directionToMouse.normalized * 500f);
					}
				}
			}

		}
	
	}
}
