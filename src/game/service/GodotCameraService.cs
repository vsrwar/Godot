using Godot;
using UmaOdisseiaBrasileira.game.model;
using UmaOdisseiaBrasileira.game.presenter.service;

namespace UmaOdisseiaBrasileira.game.service;

public partial class GodotCameraService : Node, ICameraService
{
	private Camera2D _camera;

	public GodotCameraService(Camera2D camera)
	{
		_camera = camera;
	}

	public void SetLimits(float limitRight, float limitBottom)
	{
		if (_camera != null)
		{
			_camera.LimitLeft = 0;
			_camera.LimitTop = 0;
			_camera.LimitRight = (int) limitRight;
			_camera.LimitBottom = (int) limitBottom;
		}
	}

	public void UpdatePosition(Position position)
	{
		if (_camera != null)
		{
			_camera.GlobalPosition = new Vector2(position.X, position.Y);
		}
	}
}