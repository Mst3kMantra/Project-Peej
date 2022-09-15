using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboA_1 : BaseState
{
    readonly private WarriorAttackSM _sm;

    public ComboA_1(WarriorAttackSM stateMachine) : base("ComboA_1", stateMachine) {
        _sm = (WarriorAttackSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        EventManager.TriggerEvent("warriorAttackStateChange", new Dictionary<string, object> { { "warriorAttackState", _sm.GetCurrentState() } });
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_sm.blackboard.isAttackAnimFinished == true)
        {
            _sm.blackboard.isAttackAnimFinished = false;
            _sm.blackboard.isAttackAnimStarted = false;
            _sm.ChangeState(_sm.neutralState);
        }
    }
}
