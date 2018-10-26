using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;

/// <summary>
/// Ignites an enemy, dealing damage over time for x seconds
/// </summary>
public class Ignite : StatusEffect
{
    float damagerPerTick = 0;
    float duration = 0;

    bool isSpreadingFlame = false;

    public Ignite (float damage, float length)
    {
        damagerPerTick = damage;
        duration = length;
    }

    public void DoStatusEffect(IEnemy enemy)
    {

    }

}

