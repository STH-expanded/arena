using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    State currentState;

    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwtichToTheNextState(nextState);
        }
    }

    private void SwtichToTheNextState(State nextState)
    {
        currentState = nextState;
    }
}
