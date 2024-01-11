using UmaOdisseiaBrasileira.game.model;

namespace UmaOdisseiaBrasileira.game.presenter.service;

public interface ICameraService
{
	void UpdatePosition(Position position);
	void SetLimits(float limitRight, float limitBottom);
}