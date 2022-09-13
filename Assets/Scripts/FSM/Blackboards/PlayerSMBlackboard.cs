using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSMBlackboard : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.StartListening("doubleTapMove", OnDoubleTapMove);
    }

    void OnDisable()
    {
        EventManager.StopListening("doubleTapMove", OnDoubleTapMove);
    }

    public string characterSelected = "Warrior";

    #region Current States
    public string currentMovementState;
    public string currentMovementStanceState;
    public string currentWarriorAttackState;
    #endregion

    public bool isFacingRight;
    public bool isMoveDoubleTapped;
    public bool isAttacking;

    void OnDoubleTapMove(Dictionary<string, object>message)
    {
        isMoveDoubleTapped = true;
    }
}
