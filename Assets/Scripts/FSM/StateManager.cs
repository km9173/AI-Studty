
public class StateManager{

    public enum State
    {
        Patrol,
        Trace,
        Attack
    }

    private static readonly IState[] StateList = {
        new PatrolState(),
        new TraceState(),
        new AttackState()
    };

    public static IState GetIState(State state)
    {
        return StateList[(int)state];
    }
}
