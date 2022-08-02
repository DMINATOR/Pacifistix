using Godot;
using System;

public class Player : Node
{
    [Signal]
    public delegate void OnPlayerGunShootDelegate(BaseGun gun);

    // Called when player gun shoots
    public void OnPlayerGunShootDelegateCallback(BaseGun gun)
    {
        EmitSignal(nameof(OnPlayerGunShootDelegate), new Godot.Collections.Array { gun });
    }
}
