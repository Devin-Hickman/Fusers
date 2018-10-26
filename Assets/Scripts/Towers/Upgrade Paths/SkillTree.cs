using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;

abstract class SkillTree
{
    protected Dictionary<String, Skill> skills = new Dictionary<string, Skill>();

    protected List<Skill> tierOneSkills = new List<Skill>();
    protected List<Skill> tierTwoSkills = new List<Skill>();
    protected List<Skill> tierThreeSkills = new List<Skill>();

    public int pointsForTierTwoUnlock;
    public int pointsForTierThreeUnlock;
    protected bool tierTwoUnlocked = false;
    protected bool tierThreeUnlocked = false;

    Sprite sprite;

    public abstract IAttack ModifyAttack(IAttack attack);
    public abstract void ApplyTowerModifiers(BaseElementalTower tower);

    public int ResetSkill(String skillName)
    {
        int refundPoints = skills[skillName].RemoveAllSkillsLevels();
        switch (skills[skillName].GetTier())
        {
            case 1:
                if (CheckTierTwoUnlock() == false)
                {
                    foreach (Skill s in tierTwoSkills)
                    {
                        if (s.GetCurrentLevel() > 0)
                            refundPoints = ResetSkill(s.GetName());
                    }
                }
                break;
            case 2:
                if (CheckTierThreeUnlock() == false)
                {
                    foreach (Skill s in tierThreeSkills)
                    {
                        if (s.GetCurrentLevel() > 0)
                        {
                            refundPoints = ResetSkill(s.GetName());
                        }
                    }
                }
                break;
        }
        return refundPoints;
    }

    public void IncreaseSkillLevel(String skillName, int increment, int tier)
    {
        switch (tier)
        {
            case 1:
                skills[skillName].IncreaseCurrentLevel(increment);
                if (CheckUnlockedTier(skills[skillName]))
                    tierTwoUnlocked = true;
                break;
            case 2:
                if (tierTwoUnlocked)
                {
                    skills[skillName].IncreaseCurrentLevel(increment);
                    if (CheckUnlockedTier(skills[skillName]))
                        tierThreeUnlocked = true;
                }
                break;
            case 3:
                if (tierThreeUnlocked)
                    skills[skillName].IncreaseCurrentLevel(increment);
                break;
        }
        bool CheckUnlockedTier(Skill s)
        {
            return s.CurrentEqualsMaxLevel();
        }
    }

    private bool CheckTierTwoUnlock()
    {
        int count = 0;
        foreach (Skill s in tierOneSkills)
        {
            count += s.GetCurrentLevel();
        }
        return count >= pointsForTierTwoUnlock;
    }

    private bool CheckTierThreeUnlock()
    {
        int count = 0;
        foreach (Skill s in tierTwoSkills)
        {
            count += s.GetCurrentLevel();
        }
        return count >= pointsForTierThreeUnlock;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }


}

/// <summary>
/// Skills reperesent upgrades to a current tower. This struct tracks the current level of a skill, and the tier it belongs to in the tier tree
/// The effects of a skill are defined inside the skill tree.
/// </summary>

struct Skill
{
    private string skillName;
    private int currentLevel;
    private int maxLevel;
    private int tier;

    public Skill(int c, int m, int t, string s)
    {
        skillName = s;
        currentLevel = c;
        maxLevel = m;
        tier = t;
    }

    public void ResetCurrentLevelToZero()
    {
        currentLevel = 0;
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public int GetTier()
    {
        return tier;
    }

    public bool CurrentEqualsMaxLevel()
    {
        return (currentLevel == maxLevel);
    }

    public int RemoveAllSkillsLevels()
    {
        int pointRefund = currentLevel;
        currentLevel = 0;
        return pointRefund;
    }

    public int IncreaseCurrentLevel(int increment)
    {
        int extraPoints = 0;
        if(increment > 0)
        {
            if (increment + currentLevel <= maxLevel)
            {
                currentLevel += increment;
            }
            else
            {
                extraPoints = currentLevel - maxLevel + increment;
                currentLevel = maxLevel;
               
            }
        }

        return extraPoints;
    }

    public int GetMaxLevel()
    {
        return maxLevel;
    }

    public string GetName()
    {
        return skillName;
    }
}

