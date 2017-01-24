using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

	SpriteRenderer spriteRenderer;

	[SerializeField] float lifeTime = 0.5f;

	float remainingTime;

	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	void Start () {
		remainingTime = lifeTime;
	}

	// Update is fine for visual objects only
	void Update () {
		remainingTime -= Time.deltaTime;
		if (remainingTime <= 0) {
			remainingTime = 0f;
		}

		Color c = spriteRenderer.material.color;
		c.a = remainingTime / lifeTime;
		spriteRenderer.material.color = c;

		// we could also destroy without changing color, since it won't matter anymore
		if (remainingTime == 0f) {
			Destroy(gameObject);
		}
	}

}
