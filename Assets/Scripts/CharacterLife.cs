using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLife : MonoBehaviour {

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

	void Awake () {
		gameMode = FindObjectOfType<GameMode>();
		#if UNITY_EDITOR
		if (gameMode == null) {
			Debug.LogWarning("No Game Mode in the scene");
		}
		#endif
	}

	// Update is called once per frame
	void Update () {

		if (lifebefore == life) {
			if (GetComponent<PlayerCharacterController> ().player == 1) {
				gameObject.tag = "Joueur1";
				gameObject.layer = 8;

			}
			if (GetComponent<PlayerCharacterController> ().player == 2) {
				gameObject.tag = "Joueur2";
				gameObject.layer = 9;

			}
		}

		fillamount = 0.34f * life;

		if(GetComponent<PlayerCharacterController>().player == 1){
			if (fillamount >= 1) {
				healthBar1.sprite = Resources.Load<Sprite> ("Sprites/GGJ_VieSwena");
				healthBar2.sprite = Resources.Load<Sprite> ("Sprites/GGJ_VieSwena");
				healthBar3.sprite = Resources.Load<Sprite> ("Sprites/GGJ_VieSwena");
			} if (fillamount < 1) {
				healthBar1.sprite = Resources.Load<Sprite> ("Sprites/GGJ_ViePlayer1Cassee");
			} if (fillamount < 0.5F) {
				healthBar2.sprite = Resources.Load<Sprite> ("Sprites/GGJ_ViePlayer1Cassee");
			}
		}if(GetComponent<PlayerCharacterController>().player == 2){
			if (fillamount >= 1) {
				healthBar1.sprite = Resources.Load<Sprite> ("Sprites/GGJ_VieEdean");
				healthBar2.sprite = Resources.Load<Sprite> ("Sprites/GGJ_VieEdean");
				healthBar3.sprite = Resources.Load<Sprite> ("Sprites/GGJ_VieEdean");
			}if (fillamount < 1) {
				healthBar1.sprite = Resources.Load<Sprite> ("Sprites/GGJ_ViePlayer2Cassee");
			}if (fillamount < 0.5F) {
				healthBar2.sprite = Resources.Load<Sprite> ("Sprites/GGJ_ViePlayer2Cassee");
			}
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
			if(GetComponent<PlayerCharacterController>().player == 1){
				gameMode.pointJ2++;
				gameMode.ResetAfterScoring ();
			}
			if(GetComponent<PlayerCharacterController>().player == 2){
				gameMode.pointJ1++;
				gameMode.ResetAfterScoring ();
			}
		}

	}
}
