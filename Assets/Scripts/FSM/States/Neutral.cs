using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutral : BaseState
{
    readonly private WarriorAttacksSM _sm;

    public Neutral(WarriorAttacksSM stateMachine) : base("Neutral", stateMachine) {
        _sm = (WarriorAttacksSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.blackboard.currentWarriorAttackState = _sm.GetCurrentState();
        _sm.blackboard.isAttacking = false;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Input.GetButtonDown("Attack") && _sm.blackboard.currentMovementStanceState == "Grounded")
        {
            _sm.ChangeState(_sm.comboA_1State);
        }
    }

}
