using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutral : BaseState
{
    readonly private WarriorAttackSM _sm;

    public Neutral(WarriorAttackSM stateMachine) : base("Neutral", stateMachine) {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.Blackboard.CurrentWarriorAttackState = _sm.GetCurrentState();
        _sm.Blackboard.IsAttacking = false;
        _sm.Blackboard.MaxHits = 0;
        _sm.Blackboard.Damage = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Input.GetButtonDown("Attack") && _sm.Blackboard.CurrentMovementStanceState == "Grounded")
        {
            _sm.ChangeState(_sm.ComboA_1State);
        }
    }

    public override void Exit()
    {
        base.Exit();
        _sm.Blackboard.IsAttacking = true;
    }
}
