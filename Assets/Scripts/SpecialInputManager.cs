using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialInputManager : MonoBehaviour
{
    private float ButtonCooler = 0.25f;
    private int ButtonCount = 0;

    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            if (ButtonCooler > 0 && ButtonCount >= 0)
            {
                EventManager.TriggerEvent("doubleTapMove", null);
            }
            else
            {
                ButtonCooler = 0.25f;
                ButtonCount += 1;
            }
        }
        if (ButtonCooler > 0)
        {
            ButtonCooler -= 1 * Time.deltaTime;
        }
        else ButtonCount = 0;
    }
}
