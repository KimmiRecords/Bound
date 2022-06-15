using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRegen
{
    float _hpRegen;
    float _playerHpMax;

    public HPRegen(float hpr, float hpmax)
    {
        _hpRegen = hpr;
        _playerHpMax = hpmax;
    }

    public void CheckAndRegen(ref float hp)
    {
        if (hp < _playerHpMax) //regenera hp de a poco
        {
            hp += _hpRegen;
            Debug.Log("hpregen: me regenero");

            if (hp > _playerHpMax) //maxea la vida por si me paso
            {
                hp = _playerHpMax;
            }
        }
    }
}
