using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNavy : MonoBehaviour {

    public float _moveSpeed;

    private void FixedUpdate()
    {
        transform.Translate(_moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f,_moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
