using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProjectile : MonoBehaviour {


	public float speed = 5;
	public float rebound = 2;

	public bool left = false;

	Rigidbody rigid;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rigid.velocity = Vector3.zero;
		if (!left) {
			rigid.AddForce (transform.right * speed, ForceMode.VelocityChange);
		}
		if (left) {
			rigid.AddForce (-transform.right * speed, ForceMode.VelocityChange);
		}
		//if (rebound < 0) {
		//	Destroy (this.gameObject);
		//}
	}


	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Wall" ) {

			rebound--;

			if (col.contacts [0].point.x - transform.position.x >0 ) {
				transform.position = new Vector3 (transform.position.x +0.4f, transform.position.y, transform.position.z);
				transform.Rotate(new Vector3(0,0,-90));
				if (col.contacts [0].point.y - transform.position.y > 0) {
					left = false;
				}if (col.contacts [0].point.y - transform.position.y < 0) {
					left = false;
				}			

			}
			else if ( col.contacts [0].point.x - transform.position.x < 0f) {
				transform.position = new Vector3 (transform.position.x-0.4f, transform.position.y, transform.position.z);
				transform.Rotate(new Vector3(0,0,-90));
				if (col.contacts [0].point.y - transform.position.y > 0) {
					left = false;
				}if (col.contacts [0].point.y - transform.position.y < 0) {
					left = true;
				} 
			}					
		}

		if (col.gameObject.tag != "Untagged" && col.gameObject.tag != "Wall"  ) {

			if (col.gameObject.GetComponent<CharacterLife> ()) {
				col.gameObject.GetComponent<CharacterLife> ().life--;
				Destroy (this.gameObject);
			}
		}
	}


	

}
