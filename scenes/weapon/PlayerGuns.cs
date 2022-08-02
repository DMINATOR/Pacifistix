using Godot;
using System;

/// <summary>
/// Contains list of available guns and allows player to equip one
/// </summary>
public class PlayerGuns : Node2D
{
    private BaseGun _equippedGun = null;

    private Node2D _availableGuns;

    public override void _Ready()
    {
        _availableGuns = GetNode<Node2D>("AvailableGuns");
        _equippedGun = (BaseGun)_availableGuns.GetChild(0); // Assign first as equipped
    }


    // Shot from current equipped gun
    public BaseGun Shoot()
    {
        return _equippedGun.ShootProjectile();
    }

    public void Release()
    {
        _equippedGun.Release();
    }
}
