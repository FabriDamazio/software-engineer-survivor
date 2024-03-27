using Godot;
using System;

public partial class GameCamera : Camera2D
{
	private Vector2 _targetPosition = Vector2.Zero;
	public override void _Ready()
	{
		MakeCurrent();
	}

	public override void _Process(double delta)
	{
		AcquireTarget();
		GlobalPosition = GlobalPosition.Lerp(_targetPosition, (float)(1.0f - Math.Exp(-delta * 20)));
	}

	private void AcquireTarget()
	{
		var playerNodes = GetTree().GetNodesInGroup("player");

		if(playerNodes.Count > 0)
		{
			var player = playerNodes[0] as Player;
			_targetPosition = player.GlobalPosition;
		}
	}
}
