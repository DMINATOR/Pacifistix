using Godot;
using System;

public class PlayerShip : Area2D
{
    [Export]
    public int Speed = 400; // How fast the player ship will move (pixels/sec).

    private CollisionShape2D _collisionShape2D;

    public override void _Ready()
    {
        _collisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");
    }

    public override void _Process(float delta)
    {
        var velocity = Vector2.Zero; // The player's movement vector.

        if (Input.IsActionPressed(InputMapKeys.MoveRight))
        {
            velocity.x += 1;
        }

        if (Input.IsActionPressed(InputMapKeys.MoveLeft))
        {
            velocity.x -= 1;
        }

        if (Input.IsActionPressed(InputMapKeys.MoveDown))
        {
            velocity.y += 1;
        }

        if (Input.IsActionPressed(InputMapKeys.MoveUp))
        {
            velocity.y -= 1;
        }

    }
}
