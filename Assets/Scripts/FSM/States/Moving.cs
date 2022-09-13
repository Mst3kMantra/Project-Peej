using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moving : BaseState
{
    private readonly MovementSM _sm;
    private float _horizontalInput;
    private bool isFacingRight = true;


    public Moving(MovementSM stateMachine) : base("Moving", stateMachine) {
        _sm = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _sm.spriteRenderer.color = Color.red;
        _sm.blackboard.currentMovementState = _sm.GetCurrentState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_sm.blackboard.isAttacking)
        {
            _sm.ChangeState(_sm.idleState);
        }
        _horizontalInput = Input.GetAxis("Horizontal");
        if (!isAnimPlaying(_sm.animator, "Run", 0))
        {
            _sm.animator.Play("Base Layer.Run");
        }
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
        {
            stateMachine.ChangeState(_sm.idleState);
        }
        if (Input.GetButtonDown("Jump") && _sm.blackboard.currentMovementStanceState == "Grounded")
        {
            stateMachine.ChangeState(_sm.jumpingState);
        }
        if (_sm.blackboard.isMoveDoubleTapped)
        {
            _sm.blackboard.isMoveDoubleTapped = false;
            stateMachine.ChangeState(_sm.runningState);
        }

        Flip();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _sm.rigidbody.velocity;
        vel.x = _horizontalInput * (_sm.speed);
        _sm.rigidbody.velocity = vel;
    }

    bool isAnimPlaying(Animator anim, string stateName, int animLayer)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    private void Flip()
    {
        if (isFacingRight && _horizontalInput < 0f || !isFacingRight && _horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            if (!isFacingRight)
            {
                _sm.spriteRenderer.flipX = true;
            }
            else _sm.spriteRenderer.flipX = false;
            _sm.blackboard.isFacingRight = isFacingRight;
        }
    }
}
