using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour {

    [SerializeField]
    CHuman _selectedPlayer;

    // Player 1 or Player 2
    [SerializeField]
    int _playerNumber;

    [SerializeField]
    GameObject _slider;

    public int GetPlayerNumber()
    {
        return _playerNumber;
    }

    public void Attack(bool pResult)
    {
        if (pResult)
        {
            _selectedPlayer.ChangeGod(_playerNumber);
            _selectedPlayer.StartCoroutine("SphereAttack");
            //_selectedPlayer.EnableCastingParticles(_playerNumber, false);
            _selectedPlayer.PlayAttackParticles(_playerNumber);
        }
        else
        {
            _selectedPlayer.ChangeGod(0);
        }
        
    }

    public void HumanSelect(CHuman pTarget)
    {
        if (pTarget == null)
        {            
            return;
        }
        if (pTarget != _selectedPlayer)
        {
            if (pTarget.GetGod() == 0 || pTarget.GetGod() == _playerNumber)
            {
                if (_selectedPlayer != null)
                {
                    _selectedPlayer.EnableCastingParticles(_playerNumber, false);
                    _slider.SetActive(false);
                }
                _selectedPlayer = pTarget;
                if (_selectedPlayer != null)
                {
                    _selectedPlayer.EnableCastingParticles(_playerNumber, true);
                }
            }            
        }
    }

    public void SelectOff()
    {
        if (_selectedPlayer != null)
        {
            _selectedPlayer.EnableCastingParticles(_playerNumber, false);
            _slider.SetActive(false);
        }        
    }
}
