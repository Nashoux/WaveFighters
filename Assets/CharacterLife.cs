using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLife : MonoBehaviour {

	public float life = 3;

	[SerializeField]
	GameMode gameMode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (life <= 0) {
			if(GetComponent<CharacterContoller>().player == 1){
				gameMode.pointJ2++;
			}
			if(GetComponent<CharacterContoller>().player == 2){
				gameMode.pointJ1++;
			}
		}
		
	}
}
