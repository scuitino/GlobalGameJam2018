using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarMaterial : MonoBehaviour {

	public Material[] material;
	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
		rend.sharedMaterial = material [0];
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.U))
			rend.sharedMaterial = material [1];

		if(Input.GetKeyDown(KeyCode.I))
			rend.sharedMaterial = material [0];
		if(Input.GetKeyDown(KeyCode.O))
			rend.sharedMaterial = material [2];
		
	}
	public void CambiaMaterial(){
		rend.sharedMaterial = material [1];
	}

	public void CambiaMaterialReal(){
		rend.sharedMaterial = material [0];
	}
}
