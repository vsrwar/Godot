using System;
using UmaOdisseiaBrasileira.game.Enums;
using UmaOdisseiaBrasileira.game.model;

namespace UmaOdisseiaBrasileira.game.presenter.view;

public interface IPlayerView
{
	event Action<PlayerViewInput> OnInput;
	void Run(PlayerViewDirection direction);
	void Walk(PlayerViewDirection direction);
	void Stop();
	Position GetPosition();
}
