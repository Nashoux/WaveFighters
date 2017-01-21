using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour {

	new Rigidbody rigidbody;

	/* Parameters */

	public int player = 1;
	[SerializeField] float speed = 6f;
	public Vector2 moveRange = new Vector2(-10f, 10f);

	[SerializeField] float gamepadDeadZone = 0.1f;

	/* State */

	float verticalMoveIntent;
	public float lastInput = 1f;

	void Awake () {
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update () {
		float gamepadVerticalInput = Input.GetAxis(string.Format("VerticalManette{0}", player));
		float keyboardVerticalInput = Input.GetAxis(string.Format("Vertical{0}", player));

		if (gamepadVerticalInput > gamepadDeadZone || keyboardVerticalInput > 0f) {
			verticalMoveIntent = 1f;
		}
		else if (gamepadVerticalInput < - gamepadDeadZone || keyboardVerticalInput < 0f) {
			verticalMoveIntent = -1f;
		}
		else {
			verticalMoveIntent = 0f;
		}


//
//		if (verticalMoveIntent > 0f && transform.position.y > -9.4f ){
//
//			gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,transform.position.y-3,transform.position.z), );
//				lastInput = -1;
//			} else if ((Input.GetAxis ("VerticalManette1") > 0 || Input.GetAxis ("Vertical") > 0) && transform.position.y < 9.4f){
//
//			gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,transform.position.y+3,transform.position.z), speed*Time.deltaTime);
//				lastInput = 1;
//
//			}
//		break;
//
//		case 2:
//
//			if (Input.GetAxis ("VerticalManette2") < 0  && transform.position.y > -9.4f) {
//
//				gameObject.transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, transform.position.y - 3, transform.position.z), speed * Time.deltaTime);
//				lastInput = -1;
//			} else if (Input.GetAxis ("VerticalManette2") > 0 && transform.position.y < 9.4f) {
//
//				gameObject.transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z), speed * Time.deltaTime);
//				lastInput = 1;
//
//			}
//			break;

	}

	void FixedUpdate () {
		if (verticalMoveIntent != 0f) {
			Vector3 newPosition = rigidbody.position + verticalMoveIntent * speed * Time.deltaTime * Vector3.up;
			newPosition.y = Mathf.Clamp(newPosition.y, moveRange[0], moveRange[1]);
			rigidbody.MovePosition(newPosition);
		}
	}

}
