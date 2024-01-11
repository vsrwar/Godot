using Godot;
using UmaOdisseiaBrasileira.game.model;
using UmaOdisseiaBrasileira.game.presenter;
using UmaOdisseiaBrasileira.game.presenter.service;
using UmaOdisseiaBrasileira.game.presenter.view;
using UmaOdisseiaBrasileira.game.service;

namespace UmaOdisseiaBrasileira.game.manager;

public partial class SceneManager : Node
{
	private Player _player;
	private Map _scene;
	private IPlayerView _playerView;
	private IMapView _sceneView;
	private ICameraService _cameraService;

	public override void _Ready()
	{
		var camera = GetNode<Camera2D>("Camera");
		_cameraService = new GodotCameraService(camera);

		_playerView = GetNode<IPlayerView>("Player");
		_player = new Player("Leandro Vieira");
		var playerPresenter = new PlayerPresenter(_cameraService, _player, _playerView);
		playerPresenter.Start();

		_sceneView = GetNode<IMapView>("Map");
		_scene = new Map();
		var scenePresenter = new MapPresenter(_cameraService, _scene, _sceneView);
		scenePresenter.Start();
	}
}