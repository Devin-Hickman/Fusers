using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;


/// <summary>
/// Represents a basic elemental tower that can be upgraded to a specific element
/// </summary>
class BaseElementalTower : AbstractTower
{

    int upgradePaths_Count = 0;
    int upgradePaths_Cap = 2;

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

    public void AddUpgradePath(SkillTree skillTree)
    {
        if (upgradePaths_Count < upgradePaths_Cap)
        {
            this.AddComponent<skillTree>();
            skillTree.ApplyTowerModifiers(this);
            ApplyNewSprite(skillTree.GetSprite());
        }
        else
        {
            Debug.Log("Unable to add an additional upgrade path to this tower");
        }
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

