using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMenusContinue : MonoBehaviour {

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            CGameManager.instance.StartCoroutine("StartMatch");
            gameObject.SetActive(false);            
        }
    }
}
