using Godot;
using System;

public partial class BurstShotGun : BaseGun
{
    [Export]
    public PackedScene ProjectileScene;

    [Export]
    public float ProjectileSpeed = 100; // How fast the projectile will move (pixels/sec).

    [Export]
    public float DelayBetweenShots = 0.1f; // How long we should wait before shooting another projectile (sec).

    private Marker2D _spawnLocation;

    private Timer _delayBetweenProjectilesTimer;

    public override void _Ready()
    {
        _spawnLocation = GetNode<Marker2D>("SpawnLocation");

        _delayBetweenProjectilesTimer = GetNode<Timer>("DelayBetweenProjectilesTimer");
    }

    public override BaseGun ShootProjectile()
    {
        if( _delayBetweenProjectilesTimer.TimeLeft == 0 )
        {
            ShootProjectileInternal();

            _delayBetweenProjectilesTimer.Start(DelayBetweenShots);

            // started shooting
            return this;
        }
        else
        {
            // waiting for the next shot
            return null;
        }
    }

    public override void Release()
    {
        GD.Print("Release");

        // reset timer
        _delayBetweenProjectilesTimer.Stop();
    }

    public void OnDelayBetweenProjectilesTimerTimeout()
    {
        GD.Print("Timeout");

        ShootProjectileInternal();
    }

    private void ShootProjectileInternal()
    {
        // Shoot projectile
        GD.Print("Shoot");

        var newProjectile = ProjectileScene.Instance<BulletProjectile>();
        GlobalGameState.GameplayData.GameMap.SpawnProjectile(newProjectile, _spawnLocation, this.GlobalRotation, ProjectileSpeed);
    }
}
