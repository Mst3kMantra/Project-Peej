using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float Health { get; set; }
    int HitsTaken { get; set; }
    void Damage(float damageAmount);
}
