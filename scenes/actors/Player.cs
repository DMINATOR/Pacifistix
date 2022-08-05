using Godot;
using System;

public class Player : Node
{
    [Signal]
    public delegate void OnPlayerGunShootDelegate(BaseGun gun);

    [Signal]
    public delegate void OnPlayerGunChangedDelegate(BaseGun gun);

    PlayerShip _playerShip;

    public override void _Ready()
    {
        _playerShip = GetNode<PlayerShip>("PlayerShip");
    }

    // Called when player gun shoots
    public void OnPlayerGunShootDelegateCallback(BaseGun gun)
    {
        EmitSignal(nameof(OnPlayerGunShootDelegate), gun );
    }

    // Called when player switched to another gun
    public void OnPlayerGunChangedDelegateCallback(BaseGun gun)
    {
        EmitSignal(nameof(OnPlayerGunChangedDelegate), gun );
    }

    public void EquipAGun()
    {
        var gun = _playerShip.EquipAGun();

        EmitSignal(nameof(OnPlayerGunChangedDelegate), gun);
    }
}
