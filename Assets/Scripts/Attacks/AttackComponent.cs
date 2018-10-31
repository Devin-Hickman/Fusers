using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAttackComponent : MonoBehaviour, IAttackComponent
{
    List<IStatusEffect> component_statusEffects;

    public abstract void DoAttack(float x, float y, float z);

    List<IStatusEffect> IAttackComponent.GetStatusEffects()
    {
        return component_statusEffects;
    }
}

