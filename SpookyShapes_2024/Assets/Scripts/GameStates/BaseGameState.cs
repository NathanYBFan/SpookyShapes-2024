using UnityEngine;

public class BaseGameState : IStateBase
{
    protected GameStateMachine gameStateMachine;

    public BaseGameState(GameStateMachine newStateMachine)
    {
        gameStateMachine = newStateMachine;

    }

    #region IState Methods
    public virtual void Enter()
    {
        Debug.Log("State: " + GetType().Name);
    }

    public virtual void Exit()
    {

    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void Update()
    {

    }
    #endregion

    #region Main Methods
    private void ReadMovementInput()
    {
        //if (Input == null) return;

        //// Movement input update
        //movementInput = stateMachine.Navigator.Input.AnalogueAxis;
    }
    #endregion

}
