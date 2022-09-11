using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    private GameObject playerObj = null;

    [SerializeField] private Rigidbody2D enemyRb;
    [SerializeField] private Transform playerCheck;
    [SerializeField] private LayerMask playerLayer;
    private Vector2 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
            playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerObj.transform.position;
    }

    private void FixedUpdate()
    {
        if (FoundPlayer())
        {
            enemyRb.velocity = Vector2.MoveTowards(transform.position, playerPos, speed);
        }
    }

    private bool FoundPlayer()
    {
        return Physics2D.OverlapCircle(playerCheck.position, 10f, playerLayer);
    }
}
