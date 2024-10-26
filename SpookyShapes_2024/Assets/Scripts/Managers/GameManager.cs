using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    public static GameStateMachine stateMachine = new GameStateMachine();

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.menuState);
    }

    public void MenuSetup()
    {

    }
}
