using System.Collections.Generic;
using UnityEngine;
using Unity;

public abstract class AbstractAttackComponent : MonoBehaviour, IAttackComponent
{
    private List<IStatusEffect> component_statusEffects;

    public abstract void DoAttack(float x, float y, float z);

    List<IStatusEffect> IAttackComponent.GetStatusEffects()
    {
        return component_statusEffects;
    }
}