using Godot;
using System;

public abstract class BaseGun : Node2D
{
    [Export]
    public string DisplayName;

    public virtual BaseGun ShootProjectile()
    {
        return null;
    }

    public virtual void Release()
    {

    }
}
