using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRegen
{
    //la regen de vida por composicion. es construida por PlayerStats
    //TP2 - Diego Katabian

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
            hp += _hpRegen * Time.deltaTime;

            if (hp > _playerHpMax) //maxea la vida por si me paso
            {
                hp = _playerHpMax;
            }
        }
    }
}
