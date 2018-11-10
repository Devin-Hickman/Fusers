using Fusers;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity;

internal abstract class SkillTree : MonoBehaviour, ISkillTree
{
    [SerializeField]
    protected Dictionary<String, AbstractSkill> skills = new Dictionary<string, AbstractSkill>();

    protected List<AbstractSkill> tierOneSkills = new List<AbstractSkill>();
    protected List<AbstractSkill> tierTwoSkills = new List<AbstractSkill>();
    protected List<AbstractSkill> tierThreeSkills = new List<AbstractSkill>();

    public int pointsForTierTwoUnlock;
    public int pointsForTierThreeUnlock;
    protected bool tierTwoUnlocked = false;
    protected bool tierThreeUnlocked = false;

    private Sprite sprite;

    public abstract IAttack ModifyAttack(IAttack attack);

    public int ResetSkill(String skillName)
    {
        int refundPoints = skills[skillName].RemoveAllSkillsLevels();
        switch (skills[skillName].GetTier())
        {
            case 1:
                if (CheckTierTwoUnlock() == false)
                {
                    foreach (AbstractSkill s in tierTwoSkills)
                    {
                        if (s.GetCurrentLevel() > 0)
                            refundPoints = ResetSkill(s.GetName());
                    }
                }
                break;

            case 2:
                if (CheckTierThreeUnlock() == false)
                {
                    foreach (AbstractSkill s in tierThreeSkills)
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

    public virtual void IncreaseSkillLevel(string skillName, int increment, int tier)
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
    }

    private bool CheckUnlockedTier(AbstractSkill s)
    { return s.CurrentEqualsMaxLevel(); }

    private bool CheckTierTwoUnlock()
    {
        int count = 0;
        foreach (AbstractSkill s in tierOneSkills)
        {
            count += s.GetCurrentLevel();
        }
        return count >= pointsForTierTwoUnlock;
    }

    private bool CheckTierThreeUnlock()
    {
        int count = 0;
        foreach (AbstractSkill s in tierTwoSkills)
        {
            count += s.GetCurrentLevel();
        }
        return count >= pointsForTierThreeUnlock;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    //TODO: Make Abstract/ move these to normal skill tree
    public virtual float GetDamageBoostPercentage() { return -100; }

    public virtual float GetRangeBoostPercentage()
    {
        return -100;
    }

    public virtual float GetAttackSpeedBoostPercentage()
    {
        return -100;
    }
}