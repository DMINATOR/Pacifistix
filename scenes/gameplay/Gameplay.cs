using Godot;
using System;

public class Gameplay : Node
{
    Player _player;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _player = GetNode<Player>("Game/Actors/Player");


    }


}
