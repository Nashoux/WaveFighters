using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	FMOD.Studio.EventInstance son1J1;
	FMOD.Studio.EventInstance son2J1;
	FMOD.Studio.EventInstance son3J1;
	FMOD.Studio.EventInstance son1J2;
	FMOD.Studio.EventInstance son2J2;
	FMOD.Studio.EventInstance son3J2;
		


	float[] tirsInputs = new float[3];
	Rigidbody rigid;

	float timerBase = 2f;
	float timer = 0;

	PlayerCharacterController characterController;

	void Start () {

		son1J2 = FMODUnity.RuntimeManager.CreateInstance ("event:/Sona1"); 
		son2J2 = FMODUnity.RuntimeManager.CreateInstance ("event:/Sona2"); 
		son3J2 = FMODUnity.RuntimeManager.CreateInstance ("event:/Sona3"); 
		son1J1 = FMODUnity.RuntimeManager.CreateInstance ("event:/Zaria1"); 
		son2J1 = FMODUnity.RuntimeManager.CreateInstance ("event:/Zaria2"); 
		son3J1 = FMODUnity.RuntimeManager.CreateInstance ("event:/Zaria3"); 



		characterController = GetComponent<PlayerCharacterController> ();
		rigid = GetComponent<Rigidbody>();
		tirsInputs [2] = 0;
		tirsInputs [1] = 0;
		tirsInputs [0] = 0;
	}

	void Update () {


		if (Input.GetAxis ("buton2") > 0 || characterController.player == 1 ? Input.GetKeyDown (KeyCode.A) : Input.GetKeyDown (KeyCode.Keypad1)) {

			tirsInputs [2] = tirsInputs [1];
			tirsInputs [1] = tirsInputs [0];
			tirsInputs [0] = 1;

		}if (characterController.player == 1 ? Input.GetKeyDown (KeyCode.Q) : Input.GetKeyDown (KeyCode.Keypad2)) {

			tirsInputs [2] = tirsInputs [1];
			tirsInputs [1] = tirsInputs [0];
			tirsInputs [0] = 2;

		}
		if (timer >= 0) {
			timer -= Time.deltaTime;
		}



			bool shootInput = Input.GetAxis (string.Format ("shoot{0}", characterController.player)) < 0 || (characterController.player == 1 ? Input.GetKeyDown (KeyCode.E) : Input.GetKeyDown (KeyCode.Keypad0));
			if (shootInput && tirsInputs [2] != 0) {
			if (timer <= 0) {
				timer = timerBase;
				GameObject created = Instantiate (Resources.Load<GameObject> (string.Format ("Prefab/Projectile{0}", characterController.player)));
				WaveProjectile wave = created.GetComponent<WaveProjectile> ();

				if (wave != null) {

					Vector3 spawnPosition = gameObject.transform.position + (characterController.player == 1 ? 1 : -1) * 3 * Vector3.right;

					Vector2 shootDirection = new Vector2 (characterController.directionSign, characterController.LastVerticalMove);

					int nbA = 0;
					for (int i = 0; i < tirsInputs.Length; i++) {
						if (tirsInputs [i] == 1) {
							nbA++;
						}
					}
					if (characterController.player == 1) {
						switch (nbA) {
						case 0:
							created.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/GGJ_projectile1AAA");
							wave.Setup (6, 4);
							son1J1.start ();
							break;
						case 1:
							created.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/GGJ_projectile1AAB");
							wave.Setup (8, 3);
							son2J1.start ();

							break;
						case 2:
							created.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/GGJ_projectile1BBA");
							wave.Setup (10, 2);
							son2J1.start ();

							break;
						case 3:
							created.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/GGJ_projectile1BBB");
							wave.Setup (12, 1);
							son3J1.start ();

							break;
						}
					}
					if (characterController.player == 2) {
						switch (nbA) {
						case 0:
							created.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/GGJ_projectile2AAA");
							wave.Setup (6, 4);
							son1J2.start ();

							break;
						case 1:
							created.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/GGJ_projectile2AAB");
							wave.Setup (8, 3);
							son2J2.start ();

							break;
						case 2:
							created.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/GGJ_projectile2BBA");
							wave.Setup (10, 2);
							son2J2.start ();

							break;
						case 3:
							created.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/GGJ_projectile2BBB");
							wave.Setup (12, 1);
							son3J2.start ();

							break;
						}
					}

					wave.Shoot (spawnPosition, shootDirection);
				}

			}
		}
	}
}
