using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMenusContinue : MonoBehaviour {

    [SerializeField]
    AudioSource _click;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            _click.Play();
            CGameManager.instance.StartCoroutine("StartMatch");
            gameObject.SetActive(false);            
        }
    }
}
