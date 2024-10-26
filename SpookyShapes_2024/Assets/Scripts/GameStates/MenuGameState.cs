using UnityEngine;

public class MenuGameState : BaseGameState
{
    public MenuGameState(GameStateMachine newStateMachine) : base(newStateMachine)
    {

    }

    [SerializeField] private GameObject[] Interactables;

    public override void Enter()
    {
        base.Enter();
        GameManager.Instance.MenuSetup();
    }
}
