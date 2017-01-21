using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {


	float[] tirsInputs = new float[3];
	Rigidbody rigid;

	CharacterContoller characterController;

	void Start () {
		characterController = GetComponent<CharacterContoller> ();
		rigid = GetComponent<Rigidbody>();
		tirsInputs [2] = 0;
		tirsInputs [1] = 0;
		tirsInputs [0] = 0;
	}

	void Update () {
		if (Input.GetAxis ("buton2") > 0 || Input.GetKeyDown (KeyCode.A)) {

			tirsInputs [2] = tirsInputs [1];
			tirsInputs [1] = tirsInputs [0];
			tirsInputs [0] = 1;

		}if (Input.GetKeyDown (KeyCode.Z)) {

			tirsInputs [2] = tirsInputs [1];
			tirsInputs [1] = tirsInputs [0];
			tirsInputs [0] = 2;

		}

		bool shootInput = Input.GetAxis (string.Format("shoot{0}", characterController.player)) < 0 || (characterController.player == 1 ? Input.GetKeyDown(KeyCode.E) : Input.GetKeyDown(KeyCode.Keypad0));
		if (shootInput && tirsInputs[2] != 0) {
			GameObject created = Instantiate(Resources.Load<GameObject>("Projectile1"));
			WaveProjectile wave = created.GetComponent<WaveProjectile>();

			if (wave != null) {

				Vector3 spawnPosition = gameObject.transform.position + (characterController.player == 1 ? 1 : -1) * 3 * Vector3.right;

				Vector2 shootDirection;
				if (characterController.lastInput < 0) {
					shootDirection = new Vector2(1f, -1f);
				}
				else {
					shootDirection = new Vector2(1f, 1f);
				}

				int nbA = 0;
				for (int i = 0; i < tirsInputs.Length; i++) {
					if (tirsInputs [i] == 1) {
						nbA++;
					}
				}

				switch (nbA) {
				case 0:
					wave.Setup(6, 4);
					break;
				case 1:
					wave.Setup(8, 3);
					break;
				case 2:
					wave.Setup(10, 2);
					break;
				case 3:
					wave.Setup(12, 1);
					break;
				}

				wave.Shoot(spawnPosition, shootDirection);

			}

		}
	}
}
