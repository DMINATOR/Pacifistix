using Godot;
using System;

public class Player : Node
{
    [Signal]
    public delegate void OnPlayerGunShootDelegate(BaseGun gun);

    [Signal]
    public delegate void OnPlayerGunChangedDelegate(BaseGun gun);

    [Signal]
    public delegate void OnPlayerPickupDelegate(PickupType type);

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

    // Called when player pickups
    public void OnPlayerPickupDelegateCallback(PickupType type)
    {
        if( type == PickupType.Junk )
        {
            GlobalGameState.GameplayData.JunkCollected++;
        }

        EmitSignal(nameof(OnPlayerPickupDelegate), type);
    }

    public void EquipAGun()
    {
        var gun = _playerShip.EquipAGun();

        EmitSignal(nameof(OnPlayerGunChangedDelegate), gun);
    }
}
