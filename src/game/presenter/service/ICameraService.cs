using Godot;

namespace UmaOdisseiaBrasileira.game.presenter.service;

public interface ICameraService
{
    void UpdatePosition(Vector2 position);
    void SetLimits(float limitRight, float limitBottom);
}