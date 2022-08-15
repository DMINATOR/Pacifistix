using Godot;
using System;

public class GameMap : Node2D
{
    Node2D _layers;

    Node _projectiles;

    Node _pickup;

    [Export]
    public Vector2 MovementDirection;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _layers = GetNode<Node2D>($"%{nameof(_layers)}");

        _projectiles = GetNode<Node>($"%{nameof(_projectiles)}");

        _pickup = GetNode<Node>($"%{nameof(_pickup)}");

        // Assign gamemap to global state
        GlobalGameState.GameplayData.GameMap = this;
    }


    // Constant action
    public override void _PhysicsProcess(float delta)
    {
        foreach (var node in _layers.GetChildren())
        {
            var mapLayer = (MapLayer)node;
            var position = mapLayer.Position;

            position.x += mapLayer.MovementSpeed * delta * MovementDirection.x;
            position.y += mapLayer.MovementSpeed * delta * MovementDirection.y;

           // GD.Print($"{position}");
            mapLayer.Position = position;
        }
    }

    public void SpawnProjectile(BulletProjectile newProjectile, Position2D spawnLocation, float rotation, float projectileSpeed)
    {
        // Apply global transform location
        newProjectile.Transform = spawnLocation.GlobalTransform;

        // Apply rotation to projectile
        newProjectile.LinearVelocity = new Vector2(0, -projectileSpeed).Rotated(rotation);

        // Add child to the root
        _projectiles.AddChild(newProjectile);
    }
}
