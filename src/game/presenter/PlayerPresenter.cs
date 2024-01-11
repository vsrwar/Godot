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
                _player.ToggleRunWalk();
                break;
            case PlayerViewInput.Up:
                HandleMovement(Direction.Back);
                break;
            case PlayerViewInput.Down:
                HandleMovement(Direction.Front);
                break;
            case PlayerViewInput.Left:
                HandleMovement(Direction.Left);
                break;
            case PlayerViewInput.Right:
                HandleMovement(Direction.Right);
                break;
            case PlayerViewInput.None:
            default:
                _player.Stop();
                _playerView.Stop();
                break;
        }
    }

    private void HandleMovement(Direction direction)
    {
        _player.Turn(direction);
        _playerView.Move(direction, _player.Running);
        _cameraService.UpdatePosition(_playerView.GetPosition());
    }
}