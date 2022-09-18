using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialInputManager : MonoBehaviour
{
    private float _buttonCooler = 0.25f;
    private int _buttonCount = 0;

    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            if (_buttonCooler > 0 && _buttonCount >= 0)
            {
                EventManager.TriggerEvent("DoubleTapMove", null);
            }
            else
            {
                _buttonCooler = 0.25f;
                _buttonCount += 1;
            }
        }
        if (_buttonCooler > 0)
        {
            _buttonCooler -= 1 * Time.deltaTime;
        }
        else _buttonCount = 0;
    }
}
