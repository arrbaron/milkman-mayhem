using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	Rigidbody rigidbody;
	AudioSource audioSource;

	[SerializeField] float thrustForce = 650f;
	[SerializeField] float rotationThrust = 100f;

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
			Thrust();
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			audioSource.Stop();
		}
		if (Input.GetKey(KeyCode.A)) {
			Rotate(Vector3.forward);
		}
		else if (Input.GetKey(KeyCode.D)) {
			Rotate(Vector3.back);
		}
	}

	void Thrust() {
		rigidbody.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        if (!audioSource.isPlaying) audioSource.Play();
	}

	void Rotate(Vector3 direction) {
		rigidbody.freezeRotation = true;
		
		transform.Rotate(direction * rotationThrust * Time.deltaTime);

		rigidbody.freezeRotation = false;
	}

	void OnCollisionEnter(Collision otherObject) {
		if (otherObject.gameObject.tag == "Friendly") {
			print("you're fine");
		}
		else if (otherObject.gameObject.tag == "Finish") {
			print("VICTORY");
		}
		else {
			print("DIE");
		}
	}
}
