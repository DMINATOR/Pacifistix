using Godot;
using System;

public class BasicGun : Node2D
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

    public void ShootProjectile()
    {
        var newProjectile = ProjectileScene.Instance<BulletProjectile>();

        //newProjectile.Position = _projectileDirection.Points[0];
        //var direction = _projectileDirection.Points[1];

        //newProjectile.LinearVelocity = newProjectile.Position - direction;

        newProjectile.Transform = _spawnLocation.GlobalTransform;
        newProjectile.LinearVelocity = new Vector2(0, -ProjectileSpeed).Rotated(this.Rotation);

        // Add child to the root
        Owner.Owner.AddChild(newProjectile);
    }
}
