using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseState
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    protected StateMachine StateMachine;

    public BaseState(string name, StateMachine stateMachine)
    {
        this.Name = name;
        this.StateMachine = stateMachine;
    }
    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}
