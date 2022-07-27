using Godot;
using System;

// 1 - Should be loaded first - No other dependencies
public class Constants : Node
{

}

/// <summary>
/// Input map names, that should be matched with Input key.
/// 
/// Go to Project Settings -> Input
/// </summary>
public static class InputMapKeys
{
    // Movements:

    public const string MoveRight = "move_right";

    public const string MoveLeft = "move_left";

    public const string MoveUp = "move_up";

    public const string MoveDown = "move_down";
}
