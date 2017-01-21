using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {


	float[] tirsInputs = new float[3];
	Rigidbody rigid;

	CharacterContoller characterController;
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterContoller> ();
		rigid = GetComponent<Rigidbody>();
		tirsInputs [2] = 0;
		tirsInputs [1] = 0;
		tirsInputs [0] = 0;
	}

	// Update is called once per frame
	void Update () {

		switch (characterController.player) {
		case 1:

			if (Input.GetKeyDown (KeyCode.A)) {

				tirsInputs [2] = tirsInputs [1];
				tirsInputs [1] = tirsInputs [0];
				tirsInputs [0] = 1;

			}if (Input.GetKeyDown (KeyCode.Z)) {

				tirsInputs [2] = tirsInputs [1];
				tirsInputs [1] = tirsInputs [0];
				tirsInputs [0] = 2;

			}

			if (Input.GetAxis ("shoot1") < 0 && tirsInputs[2] != 0) {

				GameObject created = Instantiate(Resources.Load<GameObject>("Projectile1"));
				created.transform.position = new Vector3 (gameObject.transform.position.x + 3, gameObject.transform.position.y, created.transform.position.z);
				if (characterController.lastInput < 0) {
					created.transform.Rotate(new Vector3(0,0,-45));
				}if (characterController.lastInput > 0) {
					created.transform.Rotate(new Vector3(0,0,45));
				}

				float nbA =0;
				for (int i = 0; i < tirsInputs.Length; i++) {
					if (tirsInputs [i] == 1) {
						nbA++;
					}

				}if (nbA == 3) {
					created.GetComponent<WaveProjectile> ().speed = 12;
					created.GetComponent<WaveProjectile> ().rebound = 1;
				}else if (nbA == 2) {
					created.GetComponent<WaveProjectile> ().speed = 10;
					created.GetComponent<WaveProjectile> ().rebound = 2;
				}else if (nbA == 1) {
					created.GetComponent<WaveProjectile> ().speed = 8;
					created.GetComponent<WaveProjectile> ().rebound = 3;
				}else if (nbA == 0) {
					created.GetComponent<WaveProjectile> ().speed = 6;
					created.GetComponent<WaveProjectile> ().rebound = 4;
				}


			}



			break;


		case 2:

			if (Input.GetAxis ("button2") < 0) {

				tirsInputs [2] = tirsInputs [1];
				tirsInputs [1] = tirsInputs [0];
				tirsInputs [0] = 1;

			}if (Input.GetAxis ("button2") < 0) {

				tirsInputs [2] = tirsInputs [1];
				tirsInputs [1] = tirsInputs [0];
				tirsInputs [0] = 2;

			}

			if (Input.GetAxis ("shoot2") < 0 && tirsInputs[2] != 0) {

				GameObject created = Instantiate(Resources.Load<GameObject>("Projectile1"));
				created.transform.position = new Vector3 (gameObject.transform.position.x - 3, gameObject.transform.position.y, created.transform.position.z);
				if (characterController.lastInput < 0) {
					created.transform.Rotate(new Vector3(0,0,-45));
				}if (characterController.lastInput > 0) {
					created.transform.Rotate(new Vector3(0,0,45));
				}

				float nbA =0;
				for (int i = 0; i < tirsInputs.Length; i++) {
					if (tirsInputs [i] == 1) {
						nbA++;
					}

				}if (nbA == 3) {
					created.GetComponent<WaveProjectile> ().speed = 12;
					created.GetComponent<WaveProjectile> ().rebound = 1;
				}else if (nbA == 2) {
					created.GetComponent<WaveProjectile> ().speed = 10;
					created.GetComponent<WaveProjectile> ().rebound = 2;
				}else if (nbA == 1) {
					created.GetComponent<WaveProjectile> ().speed = 8;
					created.GetComponent<WaveProjectile> ().rebound = 3;
				}else if (nbA == 0) {
					created.GetComponent<WaveProjectile> ().speed = 6;
					created.GetComponent<WaveProjectile> ().rebound = 4;
				}


			}


			break;
		}

	}
}
