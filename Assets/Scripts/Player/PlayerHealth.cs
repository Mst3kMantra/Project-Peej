using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private float _health;
    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }
    private int _hitsTaken;
    public int HitsTaken
    {
        get { return _hitsTaken; }
        set { _hitsTaken = value; }
    }

    public void Damage(float damageAmount)
    {

    }
}
