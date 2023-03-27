using Godot;
using System;

public partial class Pickup : RigidBody2D
{
    [Export]
    public PickupType Type;
}


// Pickup Types
public enum PickupType
{
    None,
    
    // Everything left
    Junk,
}
