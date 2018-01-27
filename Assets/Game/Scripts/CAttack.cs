using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAttack : MonoBehaviour {

	[SerializeField]
    int AttackType;

    public void SetAttackType(int pType)
    {
        AttackType = pType;
    }

    public int GetAttackType()
    {
        return AttackType;
    }
}
