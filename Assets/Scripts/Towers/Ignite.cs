using System;
using UnityEngine;
using Fusers;

/// <summary>
/// Ignites an enemy, dealing damage over time for x seconds
/// </summary>
public class Ignite :  IStatusEffect
{
    float totalDamage = 0;
    float duration = 0;
    float timeLastDamageDealt;
    float timeBetweenTicks = 0.25f;

    float damagePerTick = 0;
    int numTicks = 10;

    bool isSpreadingFlame = false;

    public Ignite (float damage, float length)
    {
        totalDamage = damage;
        duration = length;

        damagePerTick = totalDamage / numTicks;
    }

    public void Construct(float damage, float length)
    {
        totalDamage = damage;
        duration = length;
    }

    //TODO: Fix this garbage. Remove direct association with enemy. Add some status handler + visitor?
    public void DoStatusEffect(IEnemy enemy)
    {
        if(Time.time > timeLastDamageDealt + timeBetweenTicks)
        {
            enemy.TakeDamage(damagePerTick);
            timeLastDamageDealt = Time.time;
        }
    }

}

