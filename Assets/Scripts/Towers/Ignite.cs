using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;

/// <summary>
/// Ignites an enemy, dealing damage over time for x seconds
/// </summary>
class Ignite : StatusEffect
{
    float damagerPerTick = 0;
    float duration = 0;

    bool isSpreadingFlame = false;

    public Ignite (float damage, float length, bool flame)
    {
        damagerPerTick = damage;
        duration = length;
        isSpreadingFlame = flame;
    }


    public override void DoStatusEffect(AbstractEnemy enemy)
    {
        enemy.OnAttacked(damagerPerTick, ElementType.FIRE);
    }
}

