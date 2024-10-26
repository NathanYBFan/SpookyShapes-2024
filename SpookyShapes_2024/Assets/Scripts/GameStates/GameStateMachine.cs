using System;

public class GameStateMachine : StateMachine
{
    public MenuGameState menuState;
    public AddSpellGameState addSpellState;
    public FightingGameState fightingState;
    public TravelGameState travelState;

    public GameStateMachine()
    {
        menuState = new MenuGameState(this);
        addSpellState = new AddSpellGameState(this);
        fightingState = new FightingGameState(this);
        travelState = new TravelGameState(this);
    }

    [Obsolete("This is not currently supported, nothing will be run in this method")]
    public void ChangeState(GameStates newState)
    {
        return;
    }
}
