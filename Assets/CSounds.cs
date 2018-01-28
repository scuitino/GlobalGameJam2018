using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSounds : MonoBehaviour {

    [SerializeField]
    List<AudioSource> _audiosSources;
    int i = 0;

    public void PlaySound()
    {
        _audiosSources[i].Play();
        i++;
    }
}
