using Godot;
using System;

public class GameplayHUD : Control
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void OnPlayerGunShootDelegateCallback(BaseGun gun)
    {
        GD.Print("shot");
    }
}
