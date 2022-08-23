using Godot;
using System;

public class GameplayHUD : Control
{
    private PlayerGunsHUD _playerGunsHUD;

    private PickupHUD _pickupHUD;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _playerGunsHUD = GetNode<PlayerGunsHUD>($"%{nameof(_playerGunsHUD)}");
        _pickupHUD = GetNode<PickupHUD>($"%{nameof(_pickupHUD)}");
    }

    public void OnPlayerGunShootDelegateCallback(BaseGun gun)
    {
        _playerGunsHUD.OnPlayerGunShot(gun);
    }

    public void OnPlayerGunChangedDelegateCallback(BaseGun gun)
    {
        GD.Print($"GameplayGunsHUD - {_playerGunsHUD},{gun}");

        _playerGunsHUD.OnPlayerGunChanged(gun);
    }
}
