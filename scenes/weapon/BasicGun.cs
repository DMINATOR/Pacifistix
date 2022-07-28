using Godot;
using System;

public class BasicGun : Node2D
{
    [Export]
    public PackedScene ProjectileScene;

    private Line2D _projectileDirection;

    public override void _Ready()
    {
        _projectileDirection = GetNode<Line2D>("ProjectileDirection");
    }

    public void ShootProjectile()
    {
        var newProjectile = ProjectileScene.Instance<BulletProjectile>();

        //var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
        //newProjectile.LinearVelocity = velocity.Rotated(direction);

        // Add child
        this.AddChild(newProjectile);
    }
}
