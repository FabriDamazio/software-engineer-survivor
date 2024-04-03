using Godot;
using System;

public partial class AbilityUpgradeCard : PanelContainer
{
	private Label _nameLabel;
	private Label _descriptionLabel;
	public override void _Ready()
	{
		_nameLabel = GetNode<Label>("%NameLabel");
		_descriptionLabel = GetNode<Label>("%DescriptionLabel");
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
}
