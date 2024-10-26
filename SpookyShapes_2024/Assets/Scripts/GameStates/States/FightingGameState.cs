using UnityEngine;

public class FightingGameState : BaseGameState
{
    public FightingGameState(GameStateMachine newStateMachine) : base(newStateMachine)
    {
        gameStateMachine = newStateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        GameManager.Instance.StartFight();
    }
}
