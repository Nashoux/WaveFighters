using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProjectile : MonoBehaviour {

	/// Speed in m/s
	float speed = 5;

	/// Number of bounces remaining
	float bounces = 2;

	new Rigidbody rigidbody;

	/* State */

	/// Collider of the last wall hit by this projectile
	Collider lastWallHit;

	void Awake () {
		rigidbody = GetComponent<Rigidbody>();
	}

	public void Setup (int initialSpeed = 5, int initialBounces = 2) {
		speed = initialSpeed;
		bounces = initialBounces;

		lastWallHit = null;
	}

	public void Shoot (Vector3 spawnPosition, Vector2 direction) {
		transform.position = spawnPosition;
		rigidbody.velocity = direction.normalized * speed;
		AlignWithDirection(rigidbody.velocity);
	}

	void OnCollisionEnter(Collision col) {

		if (col.gameObject.tag == "Wall") {

			lastWallHit = col.collider;

			DecrementBounces();

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

			// apply wall reflection to velocity
			// rigibody.velocity has already been altered by the collision
			Vector2 u = VectorUtil.ProjectOrthogonal(- col.relativeVelocity, normal);  // along tangent
			Vector2 v = VectorUtil.ProjectParallel(- col.relativeVelocity, normal);    // along normal
			Vector3 newVelocity = (Vector3) (u - v);
			rigidbody.velocity = newVelocity;

			// align object with new velocity
			AlignWithDirection(newVelocity);
		}

		if (col.gameObject.tag != "Untagged" && col.gameObject.tag != "Wall") {

			if (col.gameObject.GetComponent<CharacterLife> ()) {
				col.gameObject.GetComponent<CharacterLife> ().life--;
				Destroy (this.gameObject);
			}
		}
	}

	void AlignWithDirection(Vector3 direction) {
//		rigidbody.rotation = Quaternion.FromToRotation(Vector3.right, direction);  // 1 frame late
		transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
	}

	void DecrementBounces () {
		bounces--;
		if (bounces <= 0) {
			Die();
		}
	}

	void Die () {
		Destroy(gameObject);
	}

	public void SlowDown ()	{
		speed /= 10f;
		rigidbody.velocity = rigidbody.velocity.normalized * speed;
	}

	public void SpeedUp () {
		speed *= 10f;
		rigidbody.velocity = rigidbody.velocity.normalized * speed;
	}

}
