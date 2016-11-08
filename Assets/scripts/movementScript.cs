using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movementScript : MonoBehaviour {

	public float speed;
	public float startSpeed;

	public List<float> listOfDirs = new List<float> ();

	void Start () {
		listOfDirs.Add (90);
		listOfDirs.Add (90);
		listOfDirs.Add (-90);


		startSpeed = speed;
	}

	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed + Physics.gravity;

		Ray newRay = new Ray (transform.position, transform.forward);

		if (Physics.SphereCast(newRay,.3f,0.75f) == true){
			speed = startSpeed;

				float randomFloat = Random.value;
				if (randomFloat < .6f) {
					transform.Rotate (new Vector3 (0, 90, 0));
				} else {
					transform.Rotate (new Vector3 (0, -90, 0));
				}
		}
	}
}
