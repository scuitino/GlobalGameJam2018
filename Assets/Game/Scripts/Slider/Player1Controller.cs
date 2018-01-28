using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour {

	public bool stop;
	GameObject cube;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.F))
			//cube.GetComponent<StopSlider> ();
		


		if (Input.GetKeyDown (KeyCode.P))
			SendMessage ("StopSlider", stop = true);
	}
}
