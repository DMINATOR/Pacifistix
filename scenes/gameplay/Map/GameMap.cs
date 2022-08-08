using Godot;
using System;

public class GameMap : Node2D
{
    Node2D _layers;

    [Export]
    public Vector2 MovementDirection;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _layers = GetNode<Node2D>($"%{nameof(_layers)}");
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

            GD.Print($"{position}");
            mapLayer.Position = position;
        }
    }

}
