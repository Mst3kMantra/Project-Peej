using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : BaseState
{
    readonly private StatusSM _sm;

    public Alive(StatusSM stateMachine) : base("Alive", stateMachine) {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.Blackboard.CurrentStatusState = _sm.GetCurrentState();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

}
