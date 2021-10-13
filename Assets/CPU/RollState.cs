using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : State
{
    public override State RunCurrentState()
    {
        return this;
    }
}
