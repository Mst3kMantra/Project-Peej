using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    private GameObject _playerObj = null;

    [SerializeField] private Rigidbody2D _enemyRb;
    [SerializeField] private Transform _playerCheck;
    [SerializeField] private LayerMask _playerLayer;
    private Vector2 _playerPos;
    private bool _isPlayerFound;
    // Start is called before the first frame update
    void Start()
    {
        if (_playerObj == null)
            _playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _playerPos = _playerObj.transform.position;
        _isPlayerFound = FoundPlayer();
    }

    private void FixedUpdate()
    {
        if (_isPlayerFound)
        {
            _enemyRb.velocity = Vector2.MoveTowards(transform.position, _playerPos, _speed);
        }
    }

    private bool FoundPlayer()
    {
        return Physics2D.OverlapCircle(_playerCheck.position, 10f, _playerLayer);
    }
}
