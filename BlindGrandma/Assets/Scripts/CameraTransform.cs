using UnityEngine;
using System.Collections;

public class CameraTransform : MonoBehaviour {

    public Transform target;
    Camera myCamera;
	
    // Use this for initialization
	void Start () {
        myCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

       // myCamera.orthographicSize = (Screen.height / 150f) / 2f;

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(0, 0, -10); 
        }

	}
}
