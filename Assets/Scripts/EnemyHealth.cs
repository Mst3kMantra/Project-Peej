using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        EventManager.StartListening("AttackAnimEnd", OnAttackAnimEnd);
    }

    private void OnDisable()
    {
        EventManager.StopListening("AttackAnimEnd", OnAttackAnimEnd);
    }

    [SerializeField] private float _health;
    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }
    [SerializeField] private int _hitsTaken = 0;
    public int HitsTaken
    {
        get { return _hitsTaken; }
        set { _hitsTaken = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = 4;
    }

    public void Damage(float damageAmount)
    {
        Health -= damageAmount;
        _animator.Play("Base Layer.Hurt");
        if (Health <= 0)
        {
            _animator.Play("Base Layer.Death");
            Destroy(gameObject, 5f);
        }
    }

    void OnAttackAnimEnd(Dictionary<string, object> message)
    {
        HitsTaken = 0;
    }
}
