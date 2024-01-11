using System;
using Godot;
using UmaOdisseiaBrasileira.game.Enums;
using UmaOdisseiaBrasileira.game.presenter.view;

namespace UmaOdisseiaBrasileira.game.view;

public partial class GodotPlayerView : CharacterBody2D, IPlayerView
{
    public event Action<PlayerViewInput> OnInput;
    private const float Speed = 200.0f;
    private const float AnimationSpeed = 5f;
    private const int RunningSpeedMultiplier = 2;
    private AnimatedSprite2D _animation;
    private string _currentDirection;
    private Vector2 _velocity;

    public override void _Ready()
    {
        _animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        Turn(Direction.Front);
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

    public void Move(Direction direction, bool running = false)
    {
        Turn(direction);
        MovePlayer(running);

        if(running)
            _animation.Play(_currentDirection + "_Run", AnimationSpeed * RunningSpeedMultiplier);
        else
            _animation.Play(_currentDirection + "_Walk", AnimationSpeed);
        
    }

    public void Stop()
    {
        _velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        _velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
        Velocity = _velocity;

        _animation.Play(_currentDirection + "_Idle", AnimationSpeed);
    }

    public Vector2 GetPosition()
    {
        return Position;
    }

    private void MovePlayer(bool isRunning)
    {
        _velocity = Velocity;
        var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

        var speed = CalculateSpeed(isRunning);
        _velocity.X = direction.X * speed;
        _velocity.Y = direction.Y * speed;

        Velocity = _velocity;
        MoveAndSlide();
    }

    private float CalculateSpeed(bool isRunning)
    {
        return isRunning ? Speed * RunningSpeedMultiplier : Speed;
    }

    private void Turn(Direction direction)
    {
        _currentDirection = char.ToUpper(direction.ToString()[0]) + direction.ToString().Substring(1).ToLower();
    }
}