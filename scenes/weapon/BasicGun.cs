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

        newProjectile.Position = _projectileDirection.Points[0];
        var direction = _projectileDirection.Points[1];
        newProjectile.LinearVelocity = direction;

        // Add child
        this.AddChild(newProjectile);
    }
}
