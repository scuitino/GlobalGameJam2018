using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cButton : MonoBehaviour {

	public void PlayButton()
    {
        GetComponent<AudioSource>().Play();
    }
}
