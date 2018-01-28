using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CHuman : MonoBehaviour {

    //attacks
    [SerializeField]
    GameObject _SphereAttack;

    //Character Sprite
    SpriteRenderer _spriteRenderer;

    //which player is your god
    int _god;

    #region
    // casting particles
    [SerializeField]
    GameObject _goodCasting;
    [SerializeField]
    GameObject _badCasting;

    // Attack particles
    [SerializeField]
    GameObject _goodAttack;
    [SerializeField]
    GameObject _badAttack;

    #endregion
    private void Start()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _god = 0;
    }

    // switch god
    public void ChangeGod(int pPlayer)
    {
        _god = pPlayer;
        if (_god == 1)
        {
            _spriteRenderer.color = Color.blue;
        }
        else
        {
            if (_god == 2)
            {
                _spriteRenderer.color = Color.red;
            }
            else
            {
                _spriteRenderer.color = Color.white;
            }
        }
    }

    public int GetGod()
    {
        return _god;
    }

    // use the sphere attack
    public IEnumerator SphereAttack()
    {        
        _SphereAttack.GetComponent<CAttack>().SetAttackType(_god);
        _SphereAttack.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _SphereAttack.SetActive(false);
    }

    // to detect received attacks
    private void OnTriggerEnter(Collider pAttack)
    {
        if (pAttack.GetComponent<CAttack>() != null)
        {
            ChangeGod(pAttack.gameObject.GetComponent<CAttack>().GetAttackType());
        }             
    }

    public void EnableCastingParticles(int pPlayer, bool pState)
    {
        if (pPlayer == 1)
        {
            _goodCasting.SetActive(pState);
        }
        else
        {
            if (pPlayer == 2)
            {
                _badCasting.SetActive(pState);
            }
        }
    }

    public void PlayAttackParticles(int pPlayer)
    {
        if (pPlayer == 1)
        {
            _goodAttack.SetActive(true);
        }
        else
        {
            if (pPlayer == 2)
            {
                _badAttack.SetActive(true);
            }
        }
    }
}
