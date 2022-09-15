using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : BaseState
{
    readonly private StatusSM _sm;

    public Dead(StatusSM stateMachine) : base("Dead", stateMachine) {
        _sm = (StatusSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        EventManager.TriggerEvent("statusStateChange", new Dictionary<string, object> { { "statusState", _sm.GetCurrentState() } });
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

}
