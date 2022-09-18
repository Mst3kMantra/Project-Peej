using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : BaseState, IFlip
{
    private readonly MovementSM _sm;
    private float _horizontalInput;
    private bool _isFacingRight;

    public Running(MovementSM stateMachine) : base("Running", stateMachine) {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _sm.SpriteRenderer.color = Color.blue;
        _sm.Blackboard.CurrentMovementState = _sm.GetCurrentState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_sm.Blackboard.IsAttacking)
        {
            _sm.ChangeState(_sm.IdleState);
        }
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
        {
            StateMachine.ChangeState(_sm.IdleState);
        }
        if (Input.GetButtonDown("Jump") && _sm.Blackboard.CurrentMovementStanceState == "Grounded")
        {
            StateMachine.ChangeState(_sm.JumpingState);
        }

        Flip();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _sm.Rigidbody.velocity;
        vel.x = _horizontalInput * (_sm.RunSpeed);
        _sm.Rigidbody.velocity = vel;
    }

    public void Flip()
    {
        if (_isFacingRight && _horizontalInput < 0f || !_isFacingRight && _horizontalInput > 0f)
        {
            _isFacingRight = !_isFacingRight;
            if (!_isFacingRight)
            {
                _sm.SpriteRenderer.flipX = true;
            }
            else _sm.SpriteRenderer.flipX = false;
            _sm.Blackboard.IsFacingRight = _isFacingRight;
        }
    }
}
