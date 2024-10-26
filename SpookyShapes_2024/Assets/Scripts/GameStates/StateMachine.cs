public abstract class StateMachine
{
    protected IStateBase currentState;
    public void ChangeState(IStateBase newState)
    {
        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
    }
    public void HandleInput()
    {
        currentState?.HandleInput();
    }

    public void Update()
    {
        currentState?.Update();
    }

    public IStateBase GetCurrentState()
    {
        return currentState;
    }
}