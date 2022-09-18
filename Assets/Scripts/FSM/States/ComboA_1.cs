using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboA_1 : BaseState
{
    readonly private WarriorAttackSM _sm;
    private int _maxHits = 1;
    private float _damage = 1;

    public ComboA_1(WarriorAttackSM stateMachine) : base("ComboA_1", stateMachine) {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.Blackboard.CurrentWarriorAttackState = _sm.GetCurrentState();
        _sm.Blackboard.MaxHits = _maxHits;
        _sm.Blackboard.Damage = _damage;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_sm.Blackboard.IsAttackAnimFinished == true)
        {
            _sm.Blackboard.IsAttackAnimFinished = false;
            _sm.Blackboard.IsAttackAnimStarted = false;
            _sm.ChangeState(_sm.NeutralState);
        }
    }
}
