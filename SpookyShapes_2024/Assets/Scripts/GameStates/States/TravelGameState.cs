using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelGameState : BaseGameState
{
    public TravelGameState(GameStateMachine newStateMachine) : base(newStateMachine)
    {
        gameStateMachine = newStateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        GameManager.Instance.StartTravel();
    }
}
