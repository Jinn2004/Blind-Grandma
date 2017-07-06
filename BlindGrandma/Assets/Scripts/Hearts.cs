using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour {

	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GrammaMechanics.GetHearts () == 3)
			heart3.SetActive (true);
		if (GrammaMechanics.GetHearts () == 2) {
			heart3.SetActive (false);
			heart2.SetActive (true);
		}
		if (GrammaMechanics.GetHearts () == 1)
			heart2.SetActive (false);
		if (GrammaMechanics.GetHearts () == 0) {
			heart1.SetActive (false); 
			GrammaMechanics.SetAlive (false);
		}
			
	}
}
