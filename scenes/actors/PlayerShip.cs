using Godot;
using System;

public class PlayerShip : Area2D
{
    [Export]
    public int Speed = 400; // How fast the player ship will move (pixels/sec).

    [Signal]
    public delegate void OnPlayerGunShootDelegate(BaseGun gun);

    [Signal]
    public delegate void OnPlayerGunChangedDelegate(BaseGun gun);

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

        // Movement
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

        // Shooting
        if (Input.IsActionPressed(InputMapKeys.ShootWeapon))
        {
            StartShootingWeapon();
        }
        else if (Input.IsActionJustReleased(InputMapKeys.ShootWeapon))
        {
            StopShootingWeapon();
        }
    }

    // Constant action
    public override void _Input(InputEvent inputEvent)
    {
        BaseGun newGun = null;

        if (inputEvent.IsActionPressed(InputMapKeys.NextWeapon))
        {
            newGun = _playerGuns.EquipNextGun();
        }
        if (inputEvent.IsActionPressed(InputMapKeys.PreviousWeapon))
        {
            newGun = _playerGuns.EquipPreviousGun();
        }

        if( newGun != null )
        {
            EmitSignal(nameof(OnPlayerGunChangedDelegate), newGun );
        }
    }

    public BaseGun EquipAGun()
    {
        return _playerGuns.EquipNextGun();
    }

    private void StartShootingWeapon()
    {
        var gun = _playerGuns.Shoot();
        if (gun != null)
        {
            // Emit signal only when player actually shot a weapon
            EmitSignal(nameof(OnPlayerGunShootDelegate), gun );
        }
    }

    private void StopShootingWeapon()
    {
        _playerGuns.Release();
    }

    // Triggered when another body entered the area
    // We only want player to be affected by pickup
    public void OnBodyEnteredDelegateCallback(PhysicsBody2D body)
    {
        GD.Print($"{body}");

        if (body.IsInGroup(Groups.Pickup))
        {
            GD.Print("picker");
        }
    }

}
