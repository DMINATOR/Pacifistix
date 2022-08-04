using Godot;
using System;

public class BulletProjectile : RigidBody2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void SpawnProjectileAt(Node parent, Position2D spawnLocation, float rotation, float projectileSpeed)
    {
        // Apply global transform location
        Transform = spawnLocation.GlobalTransform;

        // Apply rotation to projectile
        LinearVelocity = new Vector2(0, -projectileSpeed).Rotated(rotation);

        // Add child to the root
        parent.AddChild(this);

    }
}
