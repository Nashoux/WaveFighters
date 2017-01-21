using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour {

	new Rigidbody rigidbody;

	/* Parameters */

	[Tooltip("Player number, 1 for left and 2 for right")]
	public int player = 1;

	[Tooltip("-1 to face left, 1 to face right")]
	public int directionSign = 1;

	[SerializeField] float speed = 6f;
	public Vector2 moveRange = new Vector2(-10f, 10f);

	[SerializeField] float gamepadDeadZone = 0.1f;

	/* State */

	float verticalMoveIntent;
	float lastVerticalMove;
	public float LastVerticalMove { get { return lastVerticalMove; } }

	void Awake () {
		rigidbody = GetComponent<Rigidbody>();
	}

	void Start () {
		Setup();
	}

	public void Setup () {
		verticalMoveIntent = 0f;
		lastVerticalMove = 0f;
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

		lastVerticalMove = verticalMoveIntent;
	}

}
