using UmaOdisseiaBrasileira.game.Enums;

namespace UmaOdisseiaBrasileira.game.model;

public class Player
{
    public bool Running { get; private set; }

    private string _name;
    private bool _stopped;
    private Direction _direction;

    public Player(string name)
    {
        _name = name;
        _stopped = true;
        _direction = Direction.Idle;
    }

    public void Walk()
    {
        _stopped = false;
        Running = false;
    }

    public void Run()
    {
        _stopped = false;
        Running = true;
    }

    public void Stop()
    {
        _stopped = true;
        Running = false;
    }

    public void Turn(Direction direction)
    {
        _direction = direction;
    }

    public void ToggleRunWalk()
    {
        if (Running)
            Walk();
        else
            Run();
    }
}