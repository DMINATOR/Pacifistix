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
        GD.Print("ready");

        _availableGuns = GetNode<Node2D>("AvailableGuns");

        EquipNextGun();
    }


    // Shot from current equipped gun
    public BaseGun Shoot()
    {
        return _equippedGun.ShootProjectile();
    }

    // Stop shooting a gun
    public void Release()
    {
        _equippedGun.Release();
    }

    // Choose 
    public BaseGun EquipNextGun()
    {
        return EquipGun(1);
    }

    public BaseGun EquipPreviousGun()
    {
        return EquipGun(-1);
    }

    public BaseGun GetEquippedGun()
    {
        GD.Print("get");

        return _equippedGun;
    }

    private BaseGun EquipGun(int direction)
    {
        var nextIndex = 0;

        if (_equippedGun != null)
        {
            nextIndex = CalculateGunIndex(_equippedGun.GetIndex() + direction);
        }

        _equippedGun = (BaseGun)_availableGuns.GetChild(nextIndex); // Assign first as equipped

        return _equippedGun;
    }

    private int CalculateGunIndex(int currentIndex)
    {
        var maxIndex = _availableGuns.GetChildCount();

        if ( currentIndex < 0 )
        {
            GD.Print($"{currentIndex} -> {maxIndex - 1}");

            return maxIndex - 1;
        }
        else
        {
            var indexMod = (currentIndex) % maxIndex;

            GD.Print($"{currentIndex} -> {indexMod}/{maxIndex}");

            return indexMod;
        }
    }
}
