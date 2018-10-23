﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FireSkillTree : SkillTree
{
    float splashRadius = 1;

    public float igniteDamage = 2;
    public float igniteDuration = 5;
    public bool spreadingFlameActive = false;

    void Start()
    {
        pointsForTierTwoUnlock = 5;
        pointsForTierThreeUnlock = 2;

        //Tier One Skills
        Skill damageBuff = new Skill(0, 5, 1, "Damage Buff");
        Skill rangeBuff = new Skill(0, 5, 1, "Range Buff");
        Skill attackSpeedBuff = new Skill(0, 5, 1, "Attack Speed Buff");

        skills.Add(damageBuff.GetName(), damageBuff);
        skills.Add(rangeBuff.GetName(), rangeBuff);
        skills.Add(attackSpeedBuff.GetName(), attackSpeedBuff);
        tierOneSkills.AddRange(new List<Skill> { damageBuff, rangeBuff, attackSpeedBuff } );

        //Tiers Two Skills
        Skill splashskill = new Skill(0, 2, 2, "Splash Damage");
        Skill burnSkill = new Skill(0, 2, 2, "Ignition");

        skills.Add(splashskill.GetName(), splashskill);
        skills.Add(burnSkill.GetName(), burnSkill);
        tierTwoSkills.AddRange(new List<Skill> { splashskill, burnSkill });

        //Tier Three Skills
        Skill explosionSkill = new Skill(0, 1, 3, "Spreading Flame");
        skills.Add(explosionSkill.GetName(), explosionSkill);
        tierThreeSkills.Add(explosionSkill);
    }

    /// <summary>
    /// Returns a pecentage modifier to increase damage
    /// </summary>
    /// <returns>
    /// Returns damager percent modifier 
    /// </returns>

    private float GetDamageBoostPercentage()
    {
        return (float)(skills["Damage Buff"].GetCurrentLevel() * 10);
    }
    /// <summary>
    /// Returns a percentage modifier to increase range
    /// </summary>
    /// <returns></returns>

    private float GetRangeBoostPercentage()
    {
        return (float)(skills["Range Buff"].GetCurrentLevel() * 5);
    }

    /// <summary>
    /// Returns a percentage modifier to increase attack speed
    /// </summary>
    /// <returns></returns>

    private float GetAttackSpeedBoostPercentage()
    {
        return (float)(skills["Attack Speed Buff"].GetCurrentLevel() * 5);
    }

    public override Attack ApplyAttackModifiers(Attack attack)
    {
        if(skills["Splash Damage"].GetCurrentLevel() > 0)
        {
            attack.AddSplashEffect(splashRadius * skills["Splash Damage"].GetCurrentLevel());
        }

        if(skills["Ignition"].GetCurrentLevel() > 0)
        {
            spreadingFlameActive = skills["Spreading Flame"].GetCurrentLevel() > 0;
            Ignite spreadingFlame = new Ignite(igniteDamage, igniteDuration, spreadingFlameActive);
            attack.AddStatusEffect(spreadingFlame);
        }
        return attack;
    }

    public override void ApplyTowerModifiers(BaseElementalTower tower)
    {
        tower.IncreaseDamageByPercent(GetDamageBoostPercentage());
        tower.IncreaseAttackSpeed(GetAttackSpeedBoostPercentage());
        tower.IncreaseRange(GetRangeBoostPercentage());
    }


}