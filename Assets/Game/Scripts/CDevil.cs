using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDevil : MonoBehaviour {

    public float _moveSpeed;

    private void FixedUpdate()
    {
        transform.Translate(_moveSpeed * Input.GetAxis("Horizontal2") * Time.deltaTime, 0f,_moveSpeed * Input.GetAxis("Vertical2") * Time.deltaTime);
    }
}
