using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;

public interface ISkillTree
{
    /// <summary>
    /// Applifies any modifiers to the attack
    /// </summary>
    /// <param name="attack">The attack to be modified</param>
    /// <returns></returns>
    IAttack ModifyAttack(IAttack attack);

    /// <summary>
    /// Resets all skill points spent in a skill to 0. Refunds points spent for new allocation
    /// </summary>
    /// <param name="skillName">Name of skill to reeset points</param>
    /// <returns>Number of skill points refunded after resetting of skill to 0</returns>
    int ResetSkill(String skillName);
    /// <summary>
    /// Increases the level of a skill
    /// </summary>
    /// <param name="skillName">Name of the skill</param>
    /// <param name="increment">Amount of points being spent to increment the skill level. 1-1 ratio. </param>
    /// <param name="tier">The tier the skills belongs to (1, 2, 3)</param>
    void IncreaseSkillLevel(String skillName, int increment, int tier);

    float GetDamageBoostPercentage();
    /// <summary>
    /// Returns a percentage modifier to increase range
    /// </summary>
    /// <returns></returns>

    float GetRangeBoostPercentage();

    /// <summary>
    /// Returns a percentage modifier to increase attack speed
    /// </summary>
    /// <returns></returns>

    float GetAttackSpeedBoostPercentage();
}

