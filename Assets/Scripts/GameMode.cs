using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameMode : MonoBehaviour {

	public float pointJ1 = 0;
	public float pointJ2 = 0;
	public float pointEnCour = 1; 

	Vector3 spawnPointJ1;
	Vector3 spawnPointJ2;

	[SerializeField]
	private Text textJ1;
	[SerializeField]
	private Text textJ2;


	void Start(){
		spawnPointJ1 = GameObject.Find ("Character1").transform.position;
		spawnPointJ2 = GameObject.Find ("Character2").transform.position;
	}

	void Update(){
		textJ1.text = "Score j1   " + pointJ1;
		textJ2.text = "Score j2   " + pointJ2;

		// exit on escape
		if (Input.GetKeyDown(KeyCode.Escape))
			ExitInGame();
	}

	void ExitInGame() {
		SceneManager.LoadScene(0);
	}

	public void ResetAfterScoring(){

		if (pointEnCour <= (pointJ1 + pointJ2)) {
			GameObject.Find ("Character1").transform.position = spawnPointJ1;
			GameObject.Find ("Character2").transform.position = spawnPointJ2;

			if(GameObject.FindGameObjectWithTag ("Joueur1")){				
				for (int i = 0; i < GameObject.FindGameObjectsWithTag ("Joueur1").Length; i++) {
					if (GameObject.FindGameObjectsWithTag ("Joueur1") [i].name != "Character1") {
						Destroy (GameObject.FindGameObjectsWithTag ("Joueur1") [i].gameObject);
					}
				}
			}
			if(GameObject.FindGameObjectWithTag ("Joueur2")){				
				for (int i = 0; i < GameObject.FindGameObjectsWithTag ("Joueur2").Length; i++) {
					if (GameObject.FindGameObjectsWithTag ("Joueur2") [i].name != "Character2") {
						Destroy (GameObject.FindGameObjectsWithTag ("Joueur2") [i].gameObject);
					}
				}
			}
			GameObject.Find ("Character1").GetComponent<CharacterLife> ().life = 3;
			GameObject.Find ("Character1").GetComponent<CharacterLife> ().lifebefore = 3;

			GameObject.Find ("Character2").GetComponent<CharacterLife> ().life = 3;
			GameObject.Find ("Character2").GetComponent<CharacterLife> ().lifebefore = 3;
			pointEnCour++;
		}

	}









}
