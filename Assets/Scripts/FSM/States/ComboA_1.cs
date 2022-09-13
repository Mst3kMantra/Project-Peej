using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboA_1 : BaseState
{
    readonly private WarriorAttacksSM _sm;

    public ComboA_1(WarriorAttacksSM stateMachine) : base("ComboA_1", stateMachine) {
        _sm = (WarriorAttacksSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.blackboard.currentWarriorAttackState = _sm.GetCurrentState();
        _sm.blackboard.isAttacking = true;
        _sm.animator.Play("Base Layer.Attack");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (!isAnimPlaying(_sm.animator, "Attack", 0))
        {
            _sm.ChangeState(_sm.neutralState);
        }
    }

    bool isAnimPlaying(Animator anim, string stateName, int animLayer)
    {
        if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(animLayer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}
