using System;
using Godot;
using UmaOdisseiaBrasileira.game.Enums;

namespace UmaOdisseiaBrasileira.game.presenter.view;

public interface IPlayerView
{
    event Action<PlayerViewInput> OnInput;
    void Move(Direction direction, bool running = false);
    void Stop();
    Vector2 GetPosition();
}