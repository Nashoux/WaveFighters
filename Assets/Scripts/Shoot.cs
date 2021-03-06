using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	Rigidbody rigid;
	PlayerCharacterController characterController;


	/* Audio */

	FMOD.Studio.EventInstance son1J1;
	FMOD.Studio.EventInstance son2J1;
	FMOD.Studio.EventInstance son3J1;
	FMOD.Studio.EventInstance son1J2;
	FMOD.Studio.EventInstance son2J2;
	FMOD.Studio.EventInstance son3J2;
		
//	float[] tirsInputs = new float[3];

	/* Parameters */

	[SerializeField] float shootInterval = 1f;
	[SerializeField] float spawnDistance = 3f;

	/* State */

	float timer;

	int shootTypeIntention; // 0 for no shoot, 1 for shoot type 1, etc.

	/* Resources */

	GameObject projectilePrefab;
	Sprite waveSprite1;  // slow
	Sprite waveSprite2;  // medium
	Sprite waveSprite3;  // fast

	void Awake () {
		characterController = GetComponent<PlayerCharacterController> ();
		rigid = GetComponent<Rigidbody>();

		projectilePrefab = Resources.Load<GameObject>(string.Format("Prefab/Projectile{0}", characterController.player));

		string spriteNamePrefix = string.Format("Sprites/GGJ_projectile{0}", characterController.player);
		waveSprite1 = Resources.Load<Sprite> (spriteNamePrefix + "BBB");
		waveSprite2 = Resources.Load<Sprite> (spriteNamePrefix + "AAB");
		waveSprite3 = Resources.Load<Sprite> (spriteNamePrefix + "AAA");
	}

	void Start () {

		son1J2 = FMODUnity.RuntimeManager.CreateInstance ("event:/Sona1"); 
		son2J2 = FMODUnity.RuntimeManager.CreateInstance ("event:/Sona2"); 
		son3J2 = FMODUnity.RuntimeManager.CreateInstance ("event:/Sona3"); 
		son1J1 = FMODUnity.RuntimeManager.CreateInstance ("event:/Zaria1"); 
		son2J1 = FMODUnity.RuntimeManager.CreateInstance ("event:/Zaria2"); 
		son3J1 = FMODUnity.RuntimeManager.CreateInstance ("event:/Zaria3"); 

//		tirsInputs [2] = 0;
//		tirsInputs [1] = 0;
//		tirsInputs [0] = 0;
//		tirsInputs [2] = 2;
//		tirsInputs [1] = 2;
//		tirsInputs [0] = 2;

		Setup();
	}

	public void Setup () {
		timer = 0f;
		shootTypeIntention = 0;
	}

	void Update () {


//		if (Input.GetAxis ("buton2") > 0 || characterController.player == 1 ? Input.GetKeyDown (KeyCode.A) : Input.GetKeyDown (KeyCode.Keypad1)) {
//
//			tirsInputs [2] = tirsInputs [1];
//			tirsInputs [1] = tirsInputs [0];
//			tirsInputs [0] = 1;
//
//		}if (characterController.player == 1 ? Input.GetKeyDown (KeyCode.Q) : Input.GetKeyDown (KeyCode.Keypad2)) {
//
//			tirsInputs [2] = tirsInputs [1];
//			tirsInputs [1] = tirsInputs [0];
//			tirsInputs [0] = 2;
//
//		}

		if (timer > 0) {
			timer -= Time.deltaTime;
		}

		string shootButtonPrefix = string.Format("Fire{0} ", characterController.player);
		if (Input.GetButtonDown(shootButtonPrefix + "1") || Input.GetButtonDown(shootButtonPrefix + "1 Manette")) {
			shootTypeIntention = 1;
		} else if (Input.GetButtonDown(shootButtonPrefix + "2") || Input.GetButtonDown(shootButtonPrefix + "2 Manette")) {
			shootTypeIntention = 2;
		} else if (Input.GetButtonDown(shootButtonPrefix + "3") || Input.GetButtonDown(shootButtonPrefix + "3 Manette")) {
			shootTypeIntention = 3;
		}
	}

	void FixedUpdate () {
		if (shootTypeIntention > 0) {
			
			int shootType = shootTypeIntention;
			shootTypeIntention = 0;  // comsume intention (input)

			if (timer <= 0) {
				timer = shootInterval;
				GameObject created = Instantiate(Resources.Load<GameObject>(string.Format("Prefab/Projectile{0}", characterController.player)));
				WaveProjectile wave = created.GetComponent<WaveProjectile>();

				if (wave != null) {

					Vector3 spawnPosition = gameObject.transform.position + characterController.directionSign * spawnDistance * Vector3.right;
					Vector2 shootDirection = new Vector2 (characterController.directionSign, characterController.LastVerticalMove);

					string spriteNamePrefix = string.Format("Sprites/GGJ_projectile{0}", characterController.player);

					SpriteRenderer waveRenderer = created.GetComponent<SpriteRenderer> ();
					switch (shootType) { 
					case 1:
						waveRenderer.sprite = waveSprite1;
//						wave.Setup (6, 4);
						wave.Setup (6, 4);
						son1J1.start ();
						break;
					case 2:
						waveRenderer.sprite = waveSprite2;
//						wave.Setup (12, 1);
						wave.Setup (10, 3);
						son2J1.start ();
						break;
					case 3:
						waveRenderer.sprite = waveSprite3;
//						wave.Setup (12, 1);
						wave.Setup (16, 1);
						son3J1.start ();
						break;
//						case 2:
//							created.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/GGJ_projectile1AAB");
//							wave.Setup (8, 3);
//							son2J1.start ();
//
//							break;
//						case 2:
//							created.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Sprites/GGJ_projectile1BBA");
//							wave.Setup (10, 2);
//							son2J1.start ();
//
//							break;

					}

					wave.Shoot (spawnPosition, shootDirection);
				}

			}
		}
	}
}
