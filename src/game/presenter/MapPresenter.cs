using UmaOdisseiaBrasileira.game.model;
using UmaOdisseiaBrasileira.game.presenter.service;
using UmaOdisseiaBrasileira.game.presenter.view;

namespace UmaOdisseiaBrasileira.game.presenter;

public class MapPresenter
{
    private readonly ICameraService _cameraService;
    private readonly Map _map;
    private readonly IMapView _view;

    public MapPresenter(ICameraService cameraService, Map map, IMapView view)
    {
        _map = map;
        _view = view;
        _cameraService = cameraService;
    }

    public void Start()
    {
        HandleResize();
        _view.OnResize += HandleResize;
    }

    private void HandleResize()
    {
        var size = _view.GetSize();
        _cameraService.SetLimits(size.Width, size.Height);
    }

}