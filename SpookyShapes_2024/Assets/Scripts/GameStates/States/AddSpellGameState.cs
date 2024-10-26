using UnityEngine;

public class AddSpellGameState : BaseGameState
{
    public AddSpellGameState(GameStateMachine newStateMachine) : base(newStateMachine)
    {
        gameStateMachine = newStateMachine;
    }

    public override void Enter()
    {
        base.Enter();
    }
}
