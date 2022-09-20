using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCharacterCollision : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _characterCollider;
    [SerializeField] private BoxCollider2D _characterColliderBlocker;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(_characterCollider, _characterColliderBlocker, true);
    }
}
