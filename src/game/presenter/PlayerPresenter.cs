using System;
using UmaOdisseiaBrasileira.game.Enums;
using UmaOdisseiaBrasileira.game.model;
using UmaOdisseiaBrasileira.game.presenter.service;
using UmaOdisseiaBrasileira.game.presenter.view;

namespace UmaOdisseiaBrasileira.game.presenter;

public class PlayerPresenter
{
	private readonly ICameraService _cameraService;
	private readonly Player _player;
	private readonly IPlayerView _playerView;
	
	public PlayerPresenter(ICameraService cameraService, Player player, IPlayerView playerView)
	{
		_cameraService = cameraService;
		_player = player;
		_playerView = playerView;
	}

	public void Start()
	{
		_playerView.OnInput += HandleOnInput;
	}

	private void HandleOnInput(PlayerViewInput input)
	{
		switch (input)
		{
			case PlayerViewInput.Run:
				ToggleRunWalk();
				break;
			case PlayerViewInput.Up:
				HandleMovement(PlayerDirection.Back, PlayerViewDirection.Back);
				break;
			case PlayerViewInput.Down:
				HandleMovement(PlayerDirection.Front, PlayerViewDirection.Front);
				break;
			case PlayerViewInput.Left:
				HandleMovement(PlayerDirection.Left, PlayerViewDirection.Left);
				break;
			case PlayerViewInput.Right:
				HandleMovement(PlayerDirection.Right, PlayerViewDirection.Right);
				break;
			case PlayerViewInput.None:
			default:
				_player.Stop();
				_playerView.Stop();
				break;
		}
	}

	private void ToggleRunWalk()
	{
		if (_player.IsRunning())
		{
			_player.Walk();
		}
		else
		{
			_player.Run();
		}
	}

	private void HandleMovement(PlayerDirection playerDirection, PlayerViewDirection viewDirection)
	{
		_player.Turn(playerDirection);
		if (_player.IsRunning())
		{
			_playerView.Run(viewDirection);
		}
		else
		{
			_playerView.Walk(viewDirection);
		}
		var position = _playerView.GetPosition();
		_cameraService.UpdatePosition(position);
	}
}
