using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMerge : MonoBehaviour {

	public GameObject gameObject;
	public GameObject car;

	public Vector3 center;
	public Vector3 touchPosition;
	public Vector3 offset;
	public Vector3 newGOCenter;

	RaycastHit hit;

	public bool dragging = false;
	public bool moveLeft = false;
	public bool moveRight = false;
	public bool moveUp = false;
	public bool moveDown = false;

	public bool canMoveLeft = false;
	public bool canMoveRight = false;
	public bool canMoveUp = false;
	public bool canMoveDown = false;

	public float moveTimer = 1.0f;

	int direction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				gameObject = hit.collider.gameObject;
				if (gameObject.tag == "car")
					{
						center = gameObject.transform.position;
						touchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						offset = touchPosition - center;
						direction = DetermineDirection ();
						dragging = true;
					Debug.Log ("hit");
					}
			}
		}

		if (Input.GetMouseButton (0)) {
			if (dragging) {
				Debug.Log ("dragged");
				touchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				newGOCenter = touchPosition - offset;
				switch (direction) {
				case 1:
					{	
						if (newGOCenter.y > center.y && canMoveUp) {
							Debug.Log ("case 1");
							moveUp = true;
							break;
						}
						if (newGOCenter.y < center.y && canMoveDown) {
							Debug.Log ("case 1.5");
							moveDown = true;
							break;
						}
						break;
					}
				case 2:
					{
						if (newGOCenter.x < center.x && canMoveLeft) {
							Debug.Log ("case 2");
							moveLeft = true;
							break;
						}
						if (newGOCenter.x > center.x && canMoveRight) {
							Debug.Log ("case 2.5");
							moveRight = true;
							break;
						}
						break;
					}
				case 3:
					{
						if (newGOCenter.x > center.x && canMoveRight) {
							Debug.Log("case 3");
							moveRight = true;
							break;
						}
						if (newGOCenter.x < center.x && canMoveLeft) {
							Debug.Log ("case 3.5");
							moveLeft = true;
							break;
						}
						break;
					}
				case 4:
					{
						if (newGOCenter.y < center.y && canMoveDown) {
							Debug.Log ("case 4");
							moveDown = true;
							break;
						}
						if (newGOCenter.y > center.y && canMoveUp) {
							Debug.Log ("case 4.5");
							moveUp = true;
							break;
						}
						break;
					}
				}	
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			dragging = false;
		}

		Merge ();

	}

	public int DetermineDirection() {
		if (gameObject.transform.rotation == Quaternion.Euler (0, 0, 0)) {
			//left to right
			if (canMoveDown != true)
				canMoveUp = true;
			return 1;
		} else if (gameObject.transform.rotation == Quaternion.Euler (0, 0, 90)) {
			// going up
			if (canMoveRight != true)
				canMoveLeft = true;
			return 2;
		} else if (gameObject.transform.rotation == Quaternion.Euler (0, 0, 270)) {
			// going down
			if (canMoveLeft != true)
				canMoveRight = true;
			return 3;
		} else if (gameObject.transform.rotation == Quaternion.Euler (0, 0, 180)) {
			// going right
			if (canMoveUp != true)
				canMoveDown = true;
			return 4;
		}
		return 0;
	}

	public void Merge() {
		if (moveLeft) {
			gameObject.transform.position += new Vector3 (-0.1f, 0, 0).normalized * Time.deltaTime;
			moveTimer -= Time.deltaTime;
			if (moveTimer <= 0.0f) {
				moveTimer = 1.0f;
				moveLeft = false;
				canMoveLeft = false;
				canMoveRight = true;
			}
		}
		if (moveRight) {
			gameObject.transform.position += new Vector3 (0.1f, 0, 0).normalized * Time.deltaTime;
			moveTimer -= Time.deltaTime;
			if (moveTimer <= 0.0f) {
				moveTimer = 1.0f;
				moveRight = false;
				canMoveRight = false;
				canMoveLeft = true;
			}
		}
		if (moveDown) {
			gameObject.transform.position += new Vector3 (0, -0.1f, 0).normalized * Time.deltaTime;
			moveTimer -= Time.deltaTime;
			if (moveTimer <= 0.0f) {
				moveTimer = 1.0f;
				moveDown = false;
				canMoveDown = false;
				canMoveUp = true;
			}
		}
		if (moveUp) {
			gameObject.transform.position += new Vector3 (0,0.1f, 0).normalized * Time.deltaTime;
			moveTimer -= Time.deltaTime;
			if (moveTimer <= 0.0f) {
				moveTimer = 1.0f;
				moveUp = false;
				canMoveUp = false;
				canMoveDown = true;
			}
		}
	}
}
