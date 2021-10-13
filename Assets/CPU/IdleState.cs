using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override State RunCurrentState()
    {
        return this;
    }
}
