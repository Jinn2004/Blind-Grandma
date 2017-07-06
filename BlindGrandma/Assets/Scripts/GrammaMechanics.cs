using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrammaMechanics : MonoBehaviour {

	public float x;
	public float y;
	private static bool alive;
	private bool isWalking;
	int randomIdle;

	private bool isHit;
	private float hitCooldown;
	public static int hearts;
	public SphereCollider grandmaCollider;

	private Animator anim;

	private float randTimer;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		hearts = 3;
		randTimer = 0.0f;
		hitCooldown = 0.0f;
		alive = true;
	}
	// Update is called once per frame
	void Update () {
		if (alive) {
			if (!isHit) {
				if (randomIdle != 10 || randTimer <= 0.0f) {
					isWalking = true;
					anim.SetBool ("isWalking", isWalking);
					transform.position += new Vector3 (x, y, 0.0f).normalized * Time.deltaTime;
					if (randTimer <= 0.0f) {
						x = Random.Range (0.0f, 0.1f);
						y = Random.Range (-0.1f, 0.1f);
						randomIdle = Random.Range (1, 11);
						Debug.Log (randomIdle);
						randTimer = 2.0f;
					}
				} else {
					isWalking = false;
					anim.SetBool ("isWalking", isWalking);
				}
				randTimer -= Time.deltaTime;
			} else {
				hitCooldown -= Time.deltaTime;
				Debug.Log (hitCooldown);
				if (hitCooldown <= 0.0f) {
					isHit = false;
					anim.SetBool ("isHit", isHit);
				}
			}
			if (hearts == 0) {
				SetAlive (false);
				levelManager.LoadLevel ("Lose");
			}
		} else {
			isWalking = false;
			anim.SetBool ("isWalking", isWalking);
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.layer == 8) {
			// bounce off

				//Debug.Log ("Collisions" + col.contacts[0].point.y);
				//Debug.Log ("Gramma" + transform.position.y);
			if (col.contacts[0].point.y > transform.position.y)
				y = Random.Range (-0.05f, -0.1f);
			else
				y = Random.Range (0.05f, 0.1f);
			randTimer = 2.0f;
			return; // exit
		} else if (col.gameObject.layer == 10) {
			if (hitCooldown <= 0.0f) {
				hearts--;
				isHit = true;
				anim.SetBool ("isHit", isHit);
				hitCooldown = 1.0f;
				isWalking = false;
				anim.SetBool ("isWalking", isWalking);
			}
		}
	}

	public static int GetHearts() {
		return hearts;
	}

	public static void SetAlive(bool setter) {
		alive = setter;
	}
}
