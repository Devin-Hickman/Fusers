using System.Collections.Generic;
using Fusers;
using UnityEngine;

//TODO: Interface/Abstract Base Class Stoff

public abstract class AbstractAttack : IAttack
{
    protected float damage;
    protected ElementType damageType;
    List<IStatusEffect> statusEffects = new List<IStatusEffect>();

    List<AbstractEnemy> invalidTargets = new List<AbstractEnemy>(); 
    List<IAttackComponent> attackComponents = new List<IAttackComponent>();

    public void AddAttackComponent(IAttackComponent component) { attackComponents.Add(component); }

    public void AddInvalidTarget(AbstractEnemy enemy) { invalidTargets.Add(enemy); }

    public void AddStatusEffect(IStatusEffect statusEffect) { statusEffects.Add(statusEffect); }
    public void AddStatusEffects(List<IStatusEffect> effects) { statusEffects.AddRange(effects); }

    public float GetDamage() { return damage; }

    public ElementType GetDamageType() { return damageType; }

    public List<IStatusEffect> GetStatusEffects(){ return statusEffects; }

    public void SetDamageType(ElementType value) { damageType = value; }


    public void ApplyDamagePercentModifiers(float percent) { damage += damage * percent / 100; }

    public void DoAttackComponents(float x, float y, float z)
    {
        foreach(IAttackComponent component in attackComponents)
        {
            component.DoAttack(x,y,z);
  
        }
    }


}

