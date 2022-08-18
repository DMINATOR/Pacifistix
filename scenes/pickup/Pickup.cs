using Godot;
using System;

public class Pickup : RigidBody2D
{
    [Export]
    public PickupType Type;
}


// Pickup Types
public enum PickupType
{
    None,
    

}
