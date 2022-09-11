using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector] public Idle idleState;
    [HideInInspector] public Moving movingState;
    [HideInInspector] public Jumping jumpingState;

    public new Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;
    public PlayerSMBlackboard blackboard;
    public float jumpingPower = 16f;

    public float speed = 4f;

    private void Awake()
    {
        idleState = new Idle(this);
        movingState = new Moving(this);
        jumpingState = new Jumping(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
