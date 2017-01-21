using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLife : MonoBehaviour {

	public float life = 3;

	GameMode gameMode;

	[SerializeField]
	private Image healthBar;

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

		fillamount = 0.34f * life;

		if (fillamount > 1) {
			healthBar.color = new Color (0.2f, 0.9f, 0.2f);
		}else if (fillamount > 0.5f) {
			healthBar.color = new Color (0.9f, 0.6f, 0.2f);
		}else if (fillamount > 0.2f) {
			healthBar.color = new Color (0.9f, 0.1f, 0.1f);

		}


		healthBar.fillAmount = fillamount;


		var wantedPos = Camera.main.WorldToScreenPoint (transform.position);
		healthBar.gameObject.transform.position = new Vector3 (wantedPos.x,wantedPos.y + 25 ,wantedPos.z) ;


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
