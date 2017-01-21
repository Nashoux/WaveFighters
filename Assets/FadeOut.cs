using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {
	// Use this for initialization
	void Start () {
		StartCoroutine ("ColorChanging");
	}

	// Update is called once per frame
	void Update () {

		if (GetComponent<SpriteRenderer> ().material.color.a <= 0.05f) {
			Destroy (this.gameObject);
		}
			

	}

	IEnumerator ColorChanging() {
		for (float f = 1f; f >= 0; f -= 0.005f) {
			Color c = GetComponent<Renderer>().material.color;
			c.a = f;
			GetComponent<SpriteRenderer>().material.color = c;
			yield return null;
		}
	}
}
