using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;

/// <summary>
/// Interface for a basic attack
/// </summary>
public interface IAttack
{
    /// <summary>
    /// Returns the Damage of the attack
    /// </summary>
    /// <returns></returns>
    float GetDamage();

    /// <summary>
    /// Returns the type of damage of the attack (Fire, Water, Earth, Air, or Normal)
    /// </summary>
    /// <returns></returns>
    ElementType GetDamageType();

    /// <summary>
    /// Sets the damage type of the attack
    /// </summary>
    /// <param name="value"></param>
    void SetDamageType(ElementType value);

    /// <summary>
    /// Adds an invalid target to the attack, preventing attacks from hitting the 
    /// wrong targets
    /// </summary>
    /// <param name="enemy"></param>
    void AddInvalidTarget(AbstractEnemy enemy);

    /// <summary>
    /// Adds an attack component to the attack such as Splash, Chain, Splitter
    /// </summary>
    /// <param name="component"></param>
    void AddAttackComponent(IAttackComponent component);

    /// <summary>
    /// Performs any special additions to the attack, comes from attack components
    /// </summary>
    void DoAttackComponents(float x, float y, float z);

    /// <summary>
    /// Applies any damage modifiers to the attack's base damage
    /// </summary>
    /// <param name="percent"></param>
    void ApplyDamagePercentModifiers(float percent);

    /// <summary>
    /// Adds any status effects to the attack
    /// </summary>
    void AddStatusEffect(IStatusEffect statusEffect);

    /// <summary>
    /// Adds a list of status effects to the attack
    /// </summary>
    /// <param name="statusEffects"></param>
    void AddStatusEffects(List<IStatusEffect> statusEffects);

    /// <summary>
    /// Returns a list of status effects associated with the attack, these effects
    /// can include DoT's, slows, armor reductions, etc..
    /// </summary>
    /// <returns></returns>
    List<IStatusEffect> GetStatusEffects();


}

