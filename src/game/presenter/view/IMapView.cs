using System;
using UmaOdisseiaBrasileira.game.model;

namespace UmaOdisseiaBrasileira.game.presenter.view;

public interface IMapView
{
    event Action OnResize;
    Size GetSize();
}