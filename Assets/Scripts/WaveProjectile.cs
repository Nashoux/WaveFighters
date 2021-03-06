﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProjectile : MonoBehaviour {

	new Rigidbody rigidbody;
	new Collider collider;

	FMOD.Studio.EventInstance sonImpact;
	FMOD.Studio.EventInstance tap;


	/* Spawn parameters */

	/// Speed in m/s
	float speed = 5;

	/// Number of bounces remaining
	float bounces = 2;

	[SerializeField] float colliderDeactivationTime = 0.1f;

	[SerializeField] float afterImageSpawnInterval = 0.2f;

	/* State */

	Vector3 currentDirection;

	/// Collider of the last wall hit by this projectile
	Collider lastWallHit;

	float timeUntilReactivation;

	float afterImageTimer;


	/* Resources */

	GameObject afterImagePrefab;

	void Awake () {
		rigidbody = GetComponent<Rigidbody>();
		collider = GetComponent<Collider>();
		sonImpact = FMODUnity.RuntimeManager.CreateInstance ("event:/Impact"); 
		tap = FMODUnity.RuntimeManager.CreateInstance ("event:/tapMur"); 

		afterImagePrefab = Resources.Load<GameObject>("Prefab/GGJ_projectile3G");
	}

	public void Setup (int initialSpeed = 5, int initialBounces = 2) {
		speed = initialSpeed;
		bounces = initialBounces;

		lastWallHit = null;
		timeUntilReactivation = 0f;
		afterImageTimer = afterImageSpawnInterval;
	}

	public void Shoot (Vector3 spawnPosition, Vector2 direction) {
		transform.position = spawnPosition;
		currentDirection = direction.normalized;
		rigidbody.velocity = currentDirection * speed;
		AlignWithDirection();
	}

	void FixedUpdate(){

		afterImageTimer -= Time.deltaTime;
		if (afterImageTimer <= 0) {
			afterImageTimer += afterImageSpawnInterval;
			GameObject creation = Instantiate(afterImagePrefab, transform.position, transform.rotation);
		}

		if (timeUntilReactivation > 0) {
			timeUntilReactivation -= Time.deltaTime;
			if (timeUntilReactivation <= 0) {
				timeUntilReactivation = 0;
				collider.enabled = true;
			}
		}

	}

	void OnCollisionEnter(Collision col) {

		if (col.gameObject.tag == "Wall" && collider.enabled) {  // make sure simultaneous collisions don't create multiple reverse direction

			#if UNITY_EDITOR
			// debug all contact normals
			for (int i = 0; i < col.contacts.Length; ++i) {
				ContactPoint contact = col.contacts[i];
				Debug.DrawRay(contact.point, contact.normal, Color.red, 1f);
			}
			#endif

			// we consider the first contact point
			ContactPoint firstContact = col.contacts[0];
			Vector2 normal = firstContact.normal;

			if (firstContact.normal.z != 0) {
				Debug.LogWarningFormat("Contact in Z: normal {0}. Check your 3D objects Z.", firstContact.normal);
				return;
			}

			tap.start ();

			lastWallHit = col.collider;

			DecrementBounces();

			// apply wall reflection to velocity
			// rigibody.velocity has already been altered by the collision
			Vector2 u = VectorUtil.ProjectOrthogonal(- col.relativeVelocity, normal);  // along tangent
			Vector2 v = VectorUtil.ProjectParallel(- col.relativeVelocity, normal);    // along normal
			Vector3 newVelocity = (Vector3) (u - v);
			rigidbody.velocity = newVelocity;
			currentDirection = newVelocity.normalized;
			// align object with new velocity
			AlignWithDirection();

			DeactiveColliderTemporarily();
		}

		else if (col.gameObject.tag == "Absorb") {
			Die();
		}

		else if (col.gameObject.tag != "Untagged" && col.gameObject.tag != "Wall") {

			if (col.gameObject.GetComponent<CharacterLife> ()) {
				col.gameObject.GetComponent<CharacterLife> ().life--;
				sonImpact.start ();
				Destroy (this.gameObject);
			}
		}

		else if (col.gameObject.tag == "DeadZone") {
			Destroy (this.gameObject);
		}
	}

 	void AlignWithDirection() {
//		rigidbody.rotation = Quaternion.FromToRotation(Vector3.right, direction);  // 1 frame late
		transform.rotation = Quaternion.FromToRotation(Vector3.right, currentDirection);
	}

	void DecrementBounces () {
		bounces--;
		if (bounces < 0) {
			Die();
		}
	}

	void DeactiveColliderTemporarily () {
		collider.enabled = false;
		timeUntilReactivation = colliderDeactivationTime;
	}

	void Die () {
		Destroy(gameObject);
	}

	public void MultiplySpeed (float factor)	{
		speed *= factor;
		rigidbody.velocity = rigidbody.velocity.normalized * speed;
	}

}
