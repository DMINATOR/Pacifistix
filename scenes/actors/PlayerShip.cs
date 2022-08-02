using Godot;
using System;

public class PlayerShip : Area2D
{
    [Export]
    public int Speed = 400; // How fast the player ship will move (pixels/sec).

    [Signal]
    public delegate void OnPlayerGunShootDelegate(BaseGun gun);

    private CollisionShape2D _collisionShape2D;

    public Vector2 ScreenSize; // Size of the game window.

    private PlayerGuns _playerGuns;

    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;

        _collisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");
        _playerGuns = GetNode<PlayerGuns>("PlayerGuns");
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

        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
        }

        // Change
        Position += velocity * delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.x, 0, ScreenSize.x),
            y: Mathf.Clamp(Position.y, 0, ScreenSize.y)
        );
    }

    // Single action
    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent.IsActionPressed(InputMapKeys.ShootWeapon))
        {
            var gun = _playerGuns.Shoot();
            if ( gun != null )
            {
                // Emit signal only when player actually shot a weapon
                EmitSignal(nameof(OnPlayerGunShootDelegate), new Godot.Collections.Array { gun });
            }
        }
    }
}
