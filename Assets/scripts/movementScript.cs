using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed + Physics.gravity;

		Ray newRay = new Ray (transform.position, transform.forward);

		if (Physics.SphereCast(newRay,.25f,1f) == true){
			float randomFloat = Random.value;
			if (randomFloat < .5f) {
				transform.Rotate (new Vector3 (0, 90, 0));
			} else {
				transform.Rotate (new Vector3 (0, -90, 0));
			}
		}
	}
}
