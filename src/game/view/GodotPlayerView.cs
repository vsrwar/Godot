using System;
using Godot;
using UmaOdisseiaBrasileira.game.Enums;
using UmaOdisseiaBrasileira.game.model;
using UmaOdisseiaBrasileira.game.presenter.view;

namespace UmaOdisseiaBrasileira.game.view;

public partial class GodotPlayerView : CharacterBody2D, IPlayerView
{
	public event Action<PlayerViewInput> OnInput;
	private const float Speed = 200.0f;
	private const float AnimationSpeed = 5f;
	private AnimatedSprite2D _animation;
	private string _currentDirection;
	private Vector2 _velocity;

	public override void _Ready()
	{
		_animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		Turn(PlayerViewDirection.Front);
		Stop();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_shift"))
		{
			OnInput?.Invoke(PlayerViewInput.Run);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("ui_right"))
		{
			OnInput?.Invoke(PlayerViewInput.Right);
		}
		else if (Input.IsActionPressed("ui_left"))
		{
			OnInput?.Invoke(PlayerViewInput.Left);
		}
		else if (Input.IsActionPressed("ui_up"))
		{
			OnInput?.Invoke(PlayerViewInput.Up);
		}
		else if (Input.IsActionPressed("ui_down"))
		{
			OnInput?.Invoke(PlayerViewInput.Down);
		}
		else
		{
			OnInput?.Invoke(PlayerViewInput.None);
		}
	}

	public void Run(PlayerViewDirection direction)
	{
		Turn(direction);
		Move(true);
		_animation.Play(_currentDirection + "_Run", AnimationSpeed * 2);
	}

	public void Walk(PlayerViewDirection direction)
	{
		Turn(direction);
		Move(false);
		_animation.Play(_currentDirection + "_Walk", AnimationSpeed);
	}

	public void Stop()
	{
		_velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		_velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		Velocity = _velocity;

		_animation.Play(_currentDirection + "_Idle", AnimationSpeed);
	}

	public Position GetPosition()
	{
		return new Position(GlobalPosition.X, GlobalPosition.Y);
	}

	private void Move(bool isRunning)
	{
		_velocity = Velocity;
		var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		var speed = isRunning ? Speed * 2 : Speed;
		_velocity.X = direction.X * speed;
		_velocity.Y = direction.Y * speed;

		Velocity = _velocity;
		MoveAndSlide();
	}

	private void Turn(PlayerViewDirection direction)
	{
		_currentDirection = char.ToUpper(direction.ToString()[0]) + direction.ToString().Substring(1).ToLower();
	}
}
