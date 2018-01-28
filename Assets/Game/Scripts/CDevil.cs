using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDevil : MonoBehaviour
{

    [SerializeField]
    float _moveSpeed;

    // layer to collide
    [SerializeField]
    LayerMask _humansLayer;

    // overlapSphere radius
    [SerializeField]
    float _selectDistance;

    // posible target
    [SerializeField]
    GameObject _targetToSelect;

    // Referece to player script
    [SerializeField]
    CPlayer _player;

    // minigame Slider
    [SerializeField]
    CSlider _slider;

    //// my rigidbody
    //private Rigidbody rb;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    private void FixedUpdate()
    {
        if (CGameManager.instance._state == CGameManager.State.PAUSED)
            return;

        transform.Translate(_moveSpeed * Input.GetAxis("Horizontal2") * Time.deltaTime, 0f, _moveSpeed * Input.GetAxis("Vertical2") * Time.deltaTime);

        //float moveHorizontal = Input.GetAxis ("Horizontal2");
        //float moveVertical = Input.GetAxis ("Vertical2");

        //Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        //rb.AddForce (movement * _moveSpeed);
    }

    private void Update()
    {
        if (CGameManager.instance._state == CGameManager.State.PAUSED)
            return;

        if (Input.GetButtonDown("Fire2"))
        {
            _slider.gameObject.SetActive(true);
            _slider.GetComponent<CSlider>().AssignPlayer(_targetToSelect.transform);
            return;
        }
        _targetToSelect = null;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _selectDistance, _humansLayer);
        Vector3 tActualPosition = transform.position;
        float closestDistanceSqr = Mathf.Infinity;

        for (int i = 0; i < hitColliders.Length; i++)
        {
            Vector3 tDirectionToTarget = hitColliders[i].transform.position - tActualPosition;
            float dSqrToTarget = tDirectionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                _targetToSelect = hitColliders[i].gameObject;
            }
        }

        if (_targetToSelect != null)
        {
            if (_targetToSelect.GetComponent<CHuman>().GetGod() == 2 || _targetToSelect.GetComponent<CHuman>().GetGod() == 0)
            {
                _player.HumanSelect(_targetToSelect.GetComponent<CHuman>());
            }
            else
            {
                _player.SelectOff();
            }
        }
        else
        {
            _player.SelectOff();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
