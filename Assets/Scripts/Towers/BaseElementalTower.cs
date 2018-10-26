using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;
using UnityEngine;
using Unity;


/// <summary>
/// Represents a basic elemental tower that can be upgraded to a specific element
/// </summary>
class BaseElementalTower : AbstractTower
{

    //TODO: Fix Elemental tower for unity's component system

    int upgradePaths_Count = 0;
    int upgradePaths_Cap = 2;

    float baseDamage;
    ElementType baseElementType = ElementType.NORMAL;

    List<ISkillTree> skillTrees = new List<ISkillTree>();

    public void Awake()
    {

    }

    public override void AddAugmentation(Augment augment)
    {
        throw new NotImplementedException();
    }

    protected override float CalculateTowerAttackDamage()
    {
        throw new NotImplementedException();
    }

    public void AddUpgradePath(ISkillTree skillTree)
    {
        if (upgradePaths_Count < upgradePaths_Cap)
        {
            this.gameObject.AddComponent<ISkillTree>();
            skillTree.ApplyTowerModifiers(this);
            ApplyNewSprite(skillTree.GetSprite());
        }
        else
        {
            Debug.Log("Unable to add an additional upgrade path to this tower");
        }
    }

    protected override IAttack ConstructAttack()
    {
        IAttack attack = new BaseAttack(baseDamage, baseElementType);
        foreach (SkillTree s in skillTrees)
        {
            s.ModifyAttack(attack);
        }
        return attack;
    }

    public void IncreaseRange(float percent)
    {
        attackRadius += attackRadius * percent;
    }

    public void IncreaseAttackSpeed(float percent)
    {
        attacksPerSecond += attacksPerSecond * percent;
    }

    public void IncreaseDamageByPercent(float percent)
    {
        attackDamage += attackDamage * percent;
    }

    private void ApplyNewSprite(Sprite s)
    {
        this.sprite = s;
    }
}

