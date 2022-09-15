using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFlip
{
    bool isFacingRight { get; set; }
    void Flip();
}
