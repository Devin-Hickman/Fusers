using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;

//TODO: Interface/Abstract Base Class Stoff

public abstract class AbstractAttack : IAttack
{
    protected float damage;
    protected ElementType damageType;
    List<StatusEffect> statusEffects = new List<StatusEffect>();

    List<AbstractEnemy> invalidTargets = new List<AbstractEnemy>();
    List<IAttack> attackComponents = new List<IAttack>();

    public float GetDamage() { return damage; }

    public ElementType GetDamageType() { return damageType; }

    public void AddAttackComponent(IAttack component) { attackComponents.Add(component); }

    public virtual List<StatusEffect> GetStatusEffects()
    {
        foreach (IAttack ac in attackComponents)
        {
            statusEffects.AddRange(ac.GetStatusEffects());
        }
        return statusEffects;
    }

    public void ApplyDamagePercentModifiers(float percent)
    {
        damage += damage * percent / 100;
    }

    public void AddStatusEffect(StatusEffect effect)
    {
        statusEffects.Add(effect);
    }

    public abstract void PerformSpecialAction();

    public void AddInvalidTarget(AbstractEnemy enemy)
    {
        invalidTargets.Add(enemy);
    }
}

