using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimation
{
    void MoveAnim(float magnitude);

    void MeleeAnim(string parameterName);
    void RangeAnim();
}
