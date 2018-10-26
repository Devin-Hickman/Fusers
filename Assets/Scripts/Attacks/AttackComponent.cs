using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AbstractAttackComponent : MonoBehaviour, IAttackComponent
{
    List<IStatusEffect> component_statusEffects;

    List<IStatusEffect> IAttackComponent.GetStatusEffects()
    {
        return component_statusEffects;
    }
}

