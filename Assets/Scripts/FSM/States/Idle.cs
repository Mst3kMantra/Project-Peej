using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
    readonly MovementSM _sm;
    private float _horizontalInput;

    public Idle(MovementSM stateMachine) : base("Idle", stateMachine)
    {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.transform.localScale = new Vector3(-1, 1, 1);
        _horizontalInput = 0f;
        _sm.spriteRenderer.color = Color.white;
        Vector2 vel = _sm.rigidbody.velocity;
        vel.x *= 0.8f;
        _sm.rigidbody.velocity = vel;
        if (!_sm.blackboard.isAttacking)
        {
            _sm.animator.Play("Base Layer.Idle");
        }
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (!_sm.blackboard.isAttacking)
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            {
                stateMachine.ChangeState(_sm.movingState);
            }
            if (Input.GetButtonDown("Jump") && _sm.blackboard.currentMovementStanceState == "Grounded")
            {
                stateMachine.ChangeState(_sm.jumpingState);
            }
        }
    }
}