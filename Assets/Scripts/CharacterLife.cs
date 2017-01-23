using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLife : MonoBehaviour {

	PlayerCharacterController characterController;

	public float life = 3;
	public float lifebefore = 3;
	GameMode gameMode;

	float timerbase =0.8f;
	float timer = 0.8f;

	[SerializeField]
	private Image healthBar1;
	[SerializeField]
	private Image healthBar2;
	[SerializeField]
	private Image healthBar3;

	float fillamount = 1;


	/* Resources */

	Sprite spriteHealthy;
	Sprite spriteBroken;

	void Awake () {
		characterController = GetComponent<PlayerCharacterController> ();

		gameMode = FindObjectOfType<GameMode>();
		#if UNITY_EDITOR
		if (gameMode == null) {
			Debug.LogWarning("No Game Mode in the scene");
		}
		#endif

		spriteHealthy = Resources.Load<Sprite> (string.Format("Sprites/GGJ_ViePlayer{0}", characterController.player));
		spriteBroken = Resources.Load<Sprite> (string.Format("Sprites/GGJ_ViePlayer{0}Cassee", characterController.player));
	}

	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (lifebefore == life) {
			gameObject.tag = string.Format("Joueur{0}", characterController.player);
			gameObject.layer = 7 + characterController.player;  // P1 -> layer 8, P2 -> layer 9
		}

		fillamount = 0.34f * life;

		if (fillamount >= 1) {
			healthBar1.sprite = spriteHealthy;
			healthBar2.sprite = spriteHealthy;
			healthBar3.sprite = spriteHealthy;
		} if (fillamount < 1) {
			healthBar1.sprite = spriteBroken;
		} if (fillamount < 0.5f) {
			healthBar2.sprite = spriteBroken;
		}

		if (lifebefore > life) {
			gameObject.tag = "Wall";
			gameObject.layer = 13;

			timer -= Time.deltaTime;

			if (timer <= 0) {
				lifebefore = life;
				timer = timerbase;
			}
		}

		var wantedPos = Camera.main.WorldToScreenPoint (transform.position);

		if (life <= 0) {
			if(characterController.player == 1){
				gameMode.pointJ2++;
				gameMode.ResetAfterScoring ();
			}
			else {
				gameMode.pointJ1++;
				gameMode.ResetAfterScoring ();
			}
		}

	}
}
