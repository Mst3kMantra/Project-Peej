using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moving : BaseState, IFlip
{
    private readonly MovementSM _sm;
    private float _horizontalInput;
    private bool _isFacingRight;

    public Moving(MovementSM stateMachine) : base("Moving", stateMachine) {
        _sm = stateMachine;
        _isFacingRight = true;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _sm.SpriteRenderer.color = Color.red;
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
        if (_sm.Blackboard.IsMoveDoubleTapped)
        {
            _sm.Blackboard.IsMoveDoubleTapped = false;
            StateMachine.ChangeState(_sm.RunningState);
        }

        Flip();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _sm.Rigidbody.velocity;
        vel.x = _horizontalInput * (_sm.Speed);
        _sm.Rigidbody.velocity = vel;
    }

    public void Flip()
    {
        if (_isFacingRight && _horizontalInput < 0f || !_isFacingRight && _horizontalInput > 0f)
        {
            _isFacingRight = !_isFacingRight;
            if (!_isFacingRight)
            {
                _sm.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else _sm.transform.localScale = new Vector3(-1f, 1f, 1f);
            _sm.Blackboard.IsFacingRight = _isFacingRight;
        }
    }
}
