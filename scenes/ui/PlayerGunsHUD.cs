using Godot;
using System;

public class PlayerGunsHUD : Control
{
    // Color at the start of the shot effect
    [Export]
    public Color GunShotEffectColorStart;

    // Color at the end of of the shot effect
    [Export]
    public Color GunShotEffectColorEnd;

    // Duration of the gun shot effect
    [Export]
    public float GunShotEffectDuration;

    // Node to update with shot effect
    private ColorRect _colorRect;

    private Tween _gunShotTween;

    private Label _gunName;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _colorRect = GetNode<ColorRect>("GunShotEffect/ColorRect");

        _gunShotTween = GetNode<Tween>("GunShotEffect/GunShotTween");

        _gunName = GetNode<Label>("Panel/GunName");
    }

    // Trigger tween event to show 
    public void OnPlayerGunShot(BaseGun gun)
    {
        _gunShotTween.InterpolateProperty(
            _colorRect,
            "color",
            GunShotEffectColorStart,
            GunShotEffectColorEnd,
            GunShotEffectDuration);

        _gunShotTween.Start();
    }

    public void GunShotTweenEnd()
    {

    }

    public void OnPlayerGunChanged(BaseGun gun)
    {
       _gunName.Text = gun.Name;
    }
}
