using Godot;
using System;

public class BurstShotGun : BaseGun
{
    [Export]
    public PackedScene ProjectileScene;

    [Export]
    public float ProjectileSpeed = 100; // How fast the projectile will move (pixels/sec).

    [Export]
    public float DelayBetweenShots = 100; // How long we should wait before shooting another projectile (msec).

    private Position2D _spawnLocation;

    private Timer _delayBetweenProjectilesTimer;

    public override void _Ready()
    {
        _spawnLocation = GetNode<Position2D>("SpawnLocation");

        _delayBetweenProjectilesTimer = GetNode<Timer>("DelayBetweenProjectilesTimer");
    }


}
