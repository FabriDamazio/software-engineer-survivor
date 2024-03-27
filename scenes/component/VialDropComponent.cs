using Godot;
using System;

public partial class VialDropComponent : Node
{
	[Export(PropertyHint.Range, "0,1,")]
	public float DropPercent = 0.5f;

	[Export]
	public PackedScene VialScene;

	[Export]
	public HealthComponent HealthComponent;

	public override void _Ready()
	{
		HealthComponent.Died += OnDied;
	}

	private void OnDied()
	{
		if(GD.Randf() > DropPercent) return;

		if(VialScene is null) return;

		if (Owner is not Node2D) return;

		Vector2 spawn_position = (Owner as Node2D).GlobalPosition;
		var vial = VialScene.Instantiate<Node2D>();
		Owner.GetParent().AddChild(vial);
		vial.GlobalPosition = spawn_position;
	}

}
