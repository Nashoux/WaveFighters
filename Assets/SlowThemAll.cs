using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowThemAll : MonoBehaviour {

	List<GameObject> enteredGameObject = new List<GameObject>();

	void Start () {

	}

	void Update () {

	}

	void OnTriggerEnter(Collider col) {

		if (!enteredGameObject.Contains(col.gameObject)) {
			enteredGameObject.Add (col.gameObject);
			col.gameObject.GetComponent<WaveProjectile>().SlowDown();
		}

	}

	void OnTriggerExit(Collider col) {

		if (enteredGameObject.Contains(col.gameObject)) {
			enteredGameObject.Remove(col.gameObject);
			col.gameObject.GetComponent<WaveProjectile>().SpeedUp();
		}

	}

}
