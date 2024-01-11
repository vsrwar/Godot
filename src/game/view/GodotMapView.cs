using System;
using Godot;
using UmaOdisseiaBrasileira.game.model;
using UmaOdisseiaBrasileira.game.presenter.view;

namespace UmaOdisseiaBrasileira.game.view;

public partial class GodotMapView : TileMap, IMapView
{
	[Export]
	public NodePath PlayerPath { get; set; }

	public event Action OnResize;
	private Vector2 _currentWindowSize;
	private Vector2 _baseResolution;
	
	private const int TileSize = 64;
	private const int DefaultLayer = 0;

	public override void _Ready()
	{
		var currentSize = GetViewport().GetVisibleRect().Size;
		_currentWindowSize = currentSize;
		_baseResolution = currentSize;
	}

	public override void _Process(double delta)
	{
		var currentSize = GetViewport().GetVisibleRect().Size;
		if (currentSize == _currentWindowSize) return;
		OnResize?.Invoke();
		_currentWindowSize = currentSize;
	}

	public Size GetSize()
	{
		var minX = int.MaxValue;
		var minY = int.MaxValue;
		var maxX = int.MinValue;
		var maxY = int.MinValue;

		foreach (var cell in GetUsedCells(DefaultLayer))
		{
			minX = Math.Min(minX, cell.X);
			minY = Math.Min(minY, cell.Y);
			maxX = Math.Max(maxX, cell.X);
			maxY = Math.Max(maxY, cell.Y);
		}

		var width = (maxX - minX + 1) * TileSize;
		var height = (maxY - minY + 1) * TileSize;

		return new Size(width, height);
	}
}