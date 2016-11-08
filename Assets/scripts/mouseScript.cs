using UnityEngine;
using System.Collections;

public class mouseScript : MonoBehaviour {
	public Transform catTransform;
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 directionToCat = catTransform.position - transform.position;
		//Debug.Log (directionToCat);

		//Debug.DrawRay (transform.position, directionToCat * 1.5f, Color.green);

		if (Vector3.Angle(transform.forward, directionToCat) < 90) {
			//Debug.Log ("Woa dere");
			Ray mouseRay = new Ray (transform.position, directionToCat);
			RaycastHit mouseHitRayInfo = new RaycastHit ();
		
			if (Physics.Raycast(mouseRay, out mouseHitRayInfo, 2.5f)){
				if (mouseHitRayInfo.collider.tag == "cat") {
					transform.Rotate (new Vector3(0, 180, 0));
					GetComponent<movementScript> ().speed = GetComponent<movementScript> ().speed * 3;
					//GetComponent<Rigidbody> ().AddForce (-directionToCat.normalized * 2000);
					Debug.Log ("Run!");
				}
			}
		}
	}
}
