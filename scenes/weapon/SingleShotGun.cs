using Godot;
using System;

public class SingleShotGun : BaseGun
{
    [Export]
    public PackedScene ProjectileScene;

    [Export]
    public float ProjectileSpeed = 100; // How fast the projectile will move (pixels/sec).

    private Position2D _spawnLocation;

    public override void _Ready()
    {
        _spawnLocation = GetNode<Position2D>("SpawnLocation");
    }

    public override void ShootProjectile()
    {
        // Create new instance
        var newProjectile = ProjectileScene.Instance<BulletProjectile>();

        // Apply global transform location
        newProjectile.Transform = _spawnLocation.GlobalTransform;

        // Apply rotation to projectile
        newProjectile.LinearVelocity = new Vector2(0, -ProjectileSpeed).Rotated(this.GlobalRotation);

        // Add child to the root
        Owner.Owner.Owner.AddChild(newProjectile);
    }
}
