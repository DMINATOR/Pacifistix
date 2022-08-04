using Godot;
using System;

public class SingleShotGun : BaseGun
{
    [Export]
    public PackedScene ProjectileScene;

    [Export]
    public float ProjectileSpeed = 100; // How fast the projectile will move (pixels/sec).

    private Position2D _spawnLocation;

    private bool _shooting;

    public override void _Ready()
    {
        _spawnLocation = GetNode<Position2D>("SpawnLocation");
        _shooting = false;
    }

    public override BaseGun ShootProjectile()
    {
        if( !_shooting)
        {
            GD.Print("Shoot");
            _shooting = true;

            var newProjectile = ProjectileScene.Instance<BulletProjectile>();
            newProjectile.SpawnProjectileAt(Owner.Owner.Owner, _spawnLocation, this.GlobalRotation, ProjectileSpeed);

            // Projectile was shot
            return this;
        }
        else
        {
            return null;
        }
    }

    public override void Release()
    {
        GD.Print("Release");
        _shooting = false;
    }
}
