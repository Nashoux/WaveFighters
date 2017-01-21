using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLife : MonoBehaviour {

	public float life = 3;

	[SerializeField]
	GameMode gameMode;

	[SerializeField]
	private Image image;


	float fillamount = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		fillamount = 0.34f * life;

		if (fillamount > 1) {
			image.color = new Color (0.2f, 0.9f, 0.2f);
		}else if (fillamount > 0.5f) {
			image.color = new Color (0.9f, 0.6f, 0.2f);
		}else if (fillamount > 0.2f) {
			image.color = new Color (0.9f, 0.1f, 0.1f);

		}


		image.fillAmount = fillamount;


		var wantedPos = Camera.main.WorldToScreenPoint (transform.position);
		image.gameObject.transform.position = new Vector3 (wantedPos.x,wantedPos.y + 25 ,wantedPos.z) ;


		if (life <= 0) {
			if(GetComponent<CharacterContoller>().player == 1){
				gameMode.pointJ2++;
				gameMode.ResetAfterScoring ();
			}
			if(GetComponent<CharacterContoller>().player == 2){
				gameMode.pointJ1++;
				gameMode.ResetAfterScoring ();
			}
		}
		
	}
}
