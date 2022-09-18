using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSMBlackboard : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.StartListening("DoubleTapMove", OnDoubleTapMove);
        EventManager.StartListening("AttackAnimStart", OnAttackAnimStart);
        EventManager.StartListening("AttackAnimEnd", OnAttackAnimEnd);
    }

    void OnDisable()
    {
        EventManager.StopListening("DoubleTapMove", OnDoubleTapMove);
        EventManager.StopListening("AttackAnimStart", OnAttackAnimStart);
        EventManager.StopListening("AttackAnimEnd", OnAttackAnimEnd);
    }

    private string _characterSelected = "Warrior";
    public string CharacterSelected
    {
        get { return _characterSelected; }
        set { _characterSelected = value; }
    }

    #region Current States
    private string _currentStatusState;
    public string CurrentStatusState
    {
        get { return _currentStatusState; }
        set { _currentStatusState = value;
            EventManager.TriggerEvent("StatusStateChange", new Dictionary<string, object> { { "StatusState", _currentStatusState } });
        }
    }
    private string _currentMovementState;
    public string CurrentMovementState
    {
        get { return _currentMovementState; }
        set { _currentMovementState = value;
            EventManager.TriggerEvent("MovementStateChange", new Dictionary<string, object> { { "MovementState", CurrentMovementState } });
        }
    }
    private string _currentMovementStanceState;
    public string CurrentMovementStanceState
    {
        get { return _currentMovementStanceState; }
        set { _currentMovementStanceState = value;
            EventManager.TriggerEvent("MovementStanceStateChange", new Dictionary<string, object> { { "MovementStanceState", CurrentMovementStanceState } });
        }
    }
    private string _currentWarriorAttackState;
    public string CurrentWarriorAttackState
    {
        get { return _currentWarriorAttackState; }
        set { _currentWarriorAttackState = value;
            EventManager.TriggerEvent("WarriorAttackStateChange", new Dictionary<string, object> { { "WarriorAttackState", CurrentWarriorAttackState } });
        }
    }
    #endregion

    private bool _isFacingRight;
    public bool IsFacingRight
    {
        get { return _isFacingRight; }
        set
        {
            _isFacingRight = value;
            EventManager.TriggerEvent("FacingChange", new Dictionary<string, object> { { "IsFacingRight", IsFacingRight } });
        }
    }
    private bool _isMoveDoubleTapped;
    public bool IsMoveDoubleTapped
    {
        get { return _isMoveDoubleTapped; }
        set { _isMoveDoubleTapped = value; }
    }
    private bool _isAttacking;
    public bool IsAttacking
    {
        get { return _isAttacking; }
        set { _isAttacking = value;
            EventManager.TriggerEvent("PlayerAttacking", new Dictionary<string, object> { { "IsAttacking", IsAttacking } });
        }
    }
    private bool _isAttackAnimStarted;
    public bool IsAttackAnimStarted
    {
        get { return _isAttackAnimStarted; }
        set { _isAttackAnimStarted = value; }
    }
    private bool _isAttackAnimFinished;
    public bool IsAttackAnimFinished
    {
        get { return _isAttackAnimFinished; }
        set { _isAttackAnimFinished = value; }
    }
    private int _maxHits;
    public int MaxHits
    {
        get { return _maxHits; }
        set { _maxHits = value; 
        EventManager.TriggerEvent("PlayerMaxHits", new Dictionary<string, object> { { "MaxHits", MaxHits } });
        }
    }
    private float _damage;
    public float Damage
    {
        get { return _damage; }
        set { _damage = value;
            EventManager.TriggerEvent("PlayerDamage", new Dictionary<string, object> { { "Damage", Damage } });
        }
    }

    void OnDoubleTapMove(Dictionary<string, object> message)
    {
        IsMoveDoubleTapped = true;
    }

    void OnAttackAnimStart(Dictionary<string, object> message)
    {
        IsAttackAnimStarted = true;
    }

    void OnAttackAnimEnd(Dictionary<string, object> message)
    {
        IsAttackAnimFinished = true;
    }
}
