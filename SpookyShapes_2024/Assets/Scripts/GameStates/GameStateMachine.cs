using System;
using UnityEngine;

public class GameStateMachine : StateMachine
{
    public MenuGameState menuState;

    public GameStateMachine()
    {
        menuState = new MenuGameState(this);

    }

    [Obsolete("This is not currently supported, nothing will be run in this method")]
    public void ChangeState(GameStates newState)
    {
        return;
    }
}
