using UnityEngine;
using System.Collections;

public class Movement_Script : MonoBehaviour {


	private bool walking = false;
	private Vector3 spawnpoint;

	// Use this for initialization
	void Start () {

		spawnpoint = transform.position;
	}

	// Update is called once per frame
	void Update () {

		if (walking) {
			transform.position = transform.position + Camera.main.transform.forward * 1.5f * Time.deltaTime;
		}

		if (transform.position.y < -10f) {
			transform.position = spawnpoint;
		}

		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (.5f, .5f, 0));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.name.Contains ("Plane")) {
				walking = false;
			} else {
				walking = true;
			}
		}
	}
}
