using Godot;
using System;

public partial class Gameplay : Node
{
    Player _player;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _player = GetNode<Player>($"%{nameof(_player)}");

        _player.EquipAGun();
    }


}
