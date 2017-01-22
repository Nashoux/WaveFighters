using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedThemAll : MonoBehaviour {

	List<GameObject> enteredGameObject = new List<GameObject>();


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){

		if (!enteredGameObject.Contains(col.gameObject)) {
			enteredGameObject.Add (col.gameObject);
			col.gameObject.GetComponent<WaveProjectile>().MultiplySpeed(2.5f);
			}

	}
	void OnTriggerExit(Collider col){

		if (enteredGameObject.Contains(col.gameObject)) {
			enteredGameObject.Remove(col.gameObject);
			col.gameObject.GetComponent<WaveProjectile>().MultiplySpeed(1/2.5f);
		}


	}
}
