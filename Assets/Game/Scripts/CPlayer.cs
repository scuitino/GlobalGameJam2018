using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour {

    [SerializeField]
    CHuman _selectedPlayer;

    // Player 1 or Player 2
    [SerializeField]
    int _playerNumber;

    private void Start()
    {
        HumanSelect(_selectedPlayer);
    }

    private void Update()
    {
        if (_playerNumber == 1 & Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Ataca el Angel");
            Attack();
        }
        if (_playerNumber == 2 & Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Ataca el Demonio");
            Attack();
        }
    }

    public void Attack()
    {
        _selectedPlayer.ChangeGod(_playerNumber);
        _selectedPlayer.StartCoroutine("SphereAttack");
        _selectedPlayer.EnableCastingParticles(_playerNumber, false);
        _selectedPlayer.PlayAttackParticles(_playerNumber);
    }

    public void HumanSelect(CHuman pTarget)
    {        
        _selectedPlayer = pTarget;        
        _selectedPlayer.EnableCastingParticles(_playerNumber, true);
    }
}
