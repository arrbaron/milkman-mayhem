using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	Rigidbody rigidbody;
	AudioSource audioSource;

	public int thrustForce = 15;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		ProcessInput();
	}

	void ProcessInput() {
		if (Input.GetKey(KeyCode.Space)) {
			rigidbody.AddRelativeForce(Vector3.up * thrustForce);
			if (!audioSource.isPlaying) audioSource.Play();

		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			audioSource.Stop();
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.Rotate(Vector3.forward);
		}
		else if (Input.GetKey(KeyCode.D)) {
			transform.Rotate(-Vector3.forward);
		}
	}
}
