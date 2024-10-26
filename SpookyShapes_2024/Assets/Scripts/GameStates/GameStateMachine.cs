using UnityEngine;

public class GameStateMachine
{

    public MenuGameState menuState;

    public GameStateMachine()
    {
        menuState = new MenuGameState(this);

    }

    public void ChangeState(GameStates newState)
    {

    }

    public void ChangeState(IStateBase newState)
    {

    }

}
