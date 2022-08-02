using Godot;
using System;

public class BurstShotGun : BaseGun
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
}
