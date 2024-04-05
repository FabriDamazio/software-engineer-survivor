using Godot;
using System;

public partial class AbilityUpgradeCard : PanelContainer
{
	private Label _nameLabel;
	private Label _descriptionLabel;

	[Signal]
	public delegate void SelectedEventHandler();

	public override void _Ready()
	{
		_nameLabel = GetNode<Label>("%NameLabel");
		_descriptionLabel = GetNode<Label>("%DescriptionLabel");
		GuiInput += OnGuiInput;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetAbilityUpgrade(AbilityUpgrade upgrade)
	{
		_nameLabel.Text = upgrade.Name;
		_descriptionLabel.Text = upgrade.Description;		
	}

	private void OnGuiInput(InputEvent @event)
	{
		if (@event.IsActionPressed("left_click"))
		{
			EmitSignal(SignalName.Selected);
		}
	}
}
