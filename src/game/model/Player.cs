using UmaOdisseiaBrasileira.game.Enums;

namespace UmaOdisseiaBrasileira.game.model;

public class Player
{
	private string _name;
	private bool _stopped;
	private bool _running;
	private PlayerDirection _direction;

	public Player(string name)
	{
		_name = name;
		_stopped = true;
		_direction = PlayerDirection.Front;
	}

	public void Walk()
	{
		_stopped = false;
		_running = false;
	}

	public void Run()
	{
		_stopped = false;
		_running = true;
	}

	public void Stop()
	{
		_stopped = true;
		_running = false;
	}

	public void Turn(PlayerDirection direction)
	{
		_direction = direction;
	}

	public bool IsRunning()
	{
		return _running;
	}
}
