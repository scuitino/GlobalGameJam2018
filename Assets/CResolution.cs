using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CResolution : MonoBehaviour {

    void Start()
    {
        // Switch to 640 x 480 fullscreen
        Screen.SetResolution(1920, 1080, true);
    }
}
