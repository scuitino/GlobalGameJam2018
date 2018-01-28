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

    [SerializeField]
    Animator _animator;

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
            if (_playerNumber == 1)
            {
                CGameManager.instance._attackSound.Play();
                CGameManager.instance._violinSound.Play();
                _animator.SetTrigger("Attack");
            }
            else if (_playerNumber == 2)
            {
                CGameManager.instance._attackSound.Play();
                CGameManager.instance._guitarSound.Play();
                _animator.SetTrigger("Attack");
            } 
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
