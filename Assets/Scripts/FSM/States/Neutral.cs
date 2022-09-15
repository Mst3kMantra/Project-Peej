using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutral : BaseState
{
    readonly private WarriorAttackSM _sm;

    public Neutral(WarriorAttackSM stateMachine) : base("Neutral", stateMachine) {
        _sm = (WarriorAttackSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        EventManager.TriggerEvent("warriorAttackStateChange", new Dictionary<string, object> { { "warriorAttackState", _sm.GetCurrentState() } });
        EventManager.TriggerEvent("playerAttacking", new Dictionary<string, object> { { "isAttacking", false } });
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Input.GetButtonDown("Attack") && _sm.blackboard.currentMovementStanceState == "Grounded")
        {
            _sm.ChangeState(_sm.comboA_1State);
        }
    }

    public override void Exit()
    {
        base.Exit();
        EventManager.TriggerEvent("playerAttacking", new Dictionary<string, object> { { "isAttacking", true } });
    }
}
