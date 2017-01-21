using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContoller : MonoBehaviour {

	float speed = 6;
	public int player = 1;
	public float lastInput = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		switch(player) {

		case 1:

			if (Input.GetAxis ("VerticalManette1") < 0){

			gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,transform.position.y-3,transform.position.z), speed*Time.deltaTime);
				lastInput = -1;
			} else if (Input.GetAxis ("VerticalManette1") > 0){

			gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,transform.position.y+3,transform.position.z), speed*Time.deltaTime);
				lastInput = 1;	

			}
		break;

		case 2:
			
			if (Input.GetAxis ("VerticalManette2") < 0) {

				gameObject.transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, transform.position.y - 3, transform.position.z), speed * Time.deltaTime);
				lastInput = -1;
			} else if (Input.GetAxis ("VerticalManette2") > 0) {

				gameObject.transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z), speed * Time.deltaTime);
				lastInput = 1;

			}
			break;

		}
	}
}
