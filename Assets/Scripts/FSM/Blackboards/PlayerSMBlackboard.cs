using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSMBlackboard : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.StartListening("statusStateChange", OnStatusStateChange);
        EventManager.StartListening("movementStateChange", OnMovementStateChange);
        EventManager.StartListening("movementStanceStateChange", OnMovementStanceStateChange);
        EventManager.StartListening("warriorAttackStateChange", OnWarriorAttackStateChange);
        EventManager.StartListening("facingChange", OnFacingChange);
        EventManager.StartListening("doubleTapMove", OnDoubleTapMove);
        EventManager.StartListening("playerAttacking", OnPlayerAttacking);
        EventManager.StartListening("attackAnimStart", OnAttackAnimStart);
        EventManager.StartListening("attackAnimEnd", OnAttackAnimEnd);
    }

    void OnDisable()
    {
        EventManager.StopListening("statusStateChange", OnStatusStateChange);
        EventManager.StopListening("movementStateChange", OnMovementStateChange);
        EventManager.StopListening("movementStanceStateChange", OnMovementStanceStateChange);
        EventManager.StopListening("warriorAttackStateChange", OnWarriorAttackStateChange);
        EventManager.StopListening("facingChange", OnFacingChange);
        EventManager.StopListening("doubleTapMove", OnDoubleTapMove);
        EventManager.StopListening("playerAttacking", OnPlayerAttacking);
        EventManager.StopListening("attackAnimStart", OnAttackAnimStart);
        EventManager.StopListening("attackAnimEnd", OnAttackAnimEnd);
    }

    public string characterSelected = "Warrior";

    #region Current States
    public string currentStatusState = "Alive";
    public string currentMovementState;
    public string currentMovementStanceState;
    public string currentWarriorAttackState;
    #endregion

    public bool isFacingRight;
    public bool isMoveDoubleTapped;
    public bool isAttacking;
    public bool isAttackAnimStarted;
    public bool isAttackAnimFinished;

    void OnStatusStateChange(Dictionary<string, object> message)
    {
        currentStatusState = (string) message["statusState"];
    }

    void OnMovementStateChange(Dictionary<string, object> message)
    {
        currentMovementState = (string) message["movementState"];
    }

    void OnMovementStanceStateChange(Dictionary<string, object> message)
    {
        currentMovementStanceState = (string) message["movementStanceState"];
    }

    void OnWarriorAttackStateChange(Dictionary<string, object> message)
    {
        currentWarriorAttackState = (string) message["warriorAttackState"];
    }

    void OnDoubleTapMove(Dictionary<string, object> message)
    {
        isMoveDoubleTapped = true;
    }

    void OnFacingChange(Dictionary<string, object> message)
    {
        isFacingRight = (bool) message["isFacingRight"];
    }

    void OnPlayerAttacking(Dictionary<string, object> message)
    {
        isAttacking = (bool) message["isAttacking"];
    }

    void OnAttackAnimStart(Dictionary<string, object> message)
    {
        isAttackAnimStarted = true;
    }

    void OnAttackAnimEnd(Dictionary<string, object> message)
    {
        isAttackAnimFinished = true;
    }
}
