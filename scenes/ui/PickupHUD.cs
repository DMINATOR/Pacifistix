using Godot;
using System;

public partial class PickupHUD : Control
{
    private Label _junkCollected;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _junkCollected = GetNode<Label>($"%{nameof(_junkCollected)}");
    }

    public void OnPickupDelegateCallback(PickupType type)
    {
        _junkCollected.Text = $"Junk = {GlobalGameState.GameplayData.JunkCollected}";
    }
}
