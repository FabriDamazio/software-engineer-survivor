using Godot;
using System.Collections.Generic;

public partial class UpgradeScreen : CanvasLayer
{
	[Export]
	public PackedScene AbilityUpgradeCardScene { get; set; }

	private HBoxContainer _cardContainer;

	public override void _Ready()
	{
		_cardContainer = GetNode<HBoxContainer>("%CardContainer");
		GetTree().Paused = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetAbilityUpgrade(AbilityUpgrade upgrade)
	{
		CreateAbilityCard(upgrade);
	}

	public void SetAbilityUpgrade(List<AbilityUpgrade> upgrades)
	{
		foreach (AbilityUpgrade upgrade in upgrades)
        {
            CreateAbilityCard(upgrade);
        }
    }

    private void CreateAbilityCard(AbilityUpgrade upgrade)
    {
        AbilityUpgradeCard card = (AbilityUpgradeCard)AbilityUpgradeCardScene.Instantiate();
        _cardContainer.AddChild(card);
        card.SetAbilityUpgrade(upgrade);
    }

}
