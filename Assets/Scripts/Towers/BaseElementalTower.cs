using Fusers;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity;

/// <summary>
/// Represents a basic elemental tower that can be upgraded to a specific element
/// </summary>
public class BaseElementalTower : AbstractTower
{
    //TODO: Fix Elemental tower for unity's component system

    private int upgradePaths_Count = 0;
    private int upgradePaths_Cap = 2;
    public bool isFireTree = false;

    protected override void Start()
    {
        base.Start();
    }

    public List<ISkillTree> skillTrees = new List<ISkillTree>();

    public override void AddAugmentation(ElementAugment augment)
    {
        throw new NotImplementedException();
    }

    protected override float CalculateTowerAttackDamage()
    {
        throw new NotImplementedException();
    }

    public void AddUpgradePath(ISkillTree skillTree)
    {
        this.gameObject.AddComponent<FireSkillTree>();
        if (upgradePaths_Count < upgradePaths_Cap)
        {
            Debug.Log("Added tree");
            skillTrees.Add(skillTree);
            IncreaseRange(skillTree.GetRangeBoostPercentage());
            IncreaseAttackSpeed(skillTree.GetAttackSpeedBoostPercentage());
            IncreaseDamageByPercent(skillTree.GetDamageBoostPercentage());
            //TODO: Sprite swapping based on skill trees on tower
            // ApplyNewSprite(skillTree.GetSprite());
            upgradePaths_Count++;
        }
        else
        {
            Debug.Log("Unable to add an additional upgrade path to this tower");
        }
    }

    protected override IAttack ConstructAttack()
    {
        IAttack attack = new BaseAttack(attackDamage, attackDamageType);
        foreach (SkillTree s in skillTrees)
        {
            s.ModifyAttack(attack);
        }
        return attack;
    }

    private void IncreaseRange(float percent)
    {
        attackRadius += attackRadius * percent;
    }

    private void IncreaseAttackSpeed(float percent)
    {
        attacksPerSecond += attacksPerSecond * percent;
    }

    private void IncreaseDamageByPercent(float percent)
    {
        attackDamage += attackDamage * percent;
    }

    private void ApplyNewSprite(Sprite s)
    {
        this.sprite = s;
    }
}