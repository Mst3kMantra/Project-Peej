using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.StartListening("PlayerMaxHits", OnPlayerMaxHits);
        EventManager.StartListening("PlayerDamage", OnPlayerDamage);
    }

    private void OnDisable()
    {
        EventManager.StopListening("PlayerMaxHits", OnPlayerMaxHits);
        EventManager.StopListening("PlayerDamage", OnPlayerDamage);
    }

    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private int _maxHits;
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var hit = other.GetComponent<IDamageable>();
        if (hit != null && hit.HitsTaken < _maxHits) {
            hit.Damage(_damage);
            hit.HitsTaken++;
        }
    }

    private void OnPlayerMaxHits(Dictionary<string, object> message)
    {
        _maxHits = (int) message["MaxHits"];
    }

    private void  OnPlayerDamage(Dictionary<string, object> message)
    {
        _damage = (float)message["Damage"];
    }
}
