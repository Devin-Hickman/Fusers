using UnityEngine;
using Unity;

/// <summary>
/// Ignites an enemy, dealing damage over time for x seconds
/// </summary>
public class Ignite : IStatusEffect
{
    private float totalDamage = 0;
    private float duration = 0;
    private float timeLastDamageDealt;
    private float timeBetweenTicks = 0.25f;

    private float damagePerTick = 0;
    private int numTicks = 10;

    private bool isSpreadingFlame = false;

    public Ignite(float damage, float length)
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
        if (Time.time > timeLastDamageDealt + timeBetweenTicks)
        {
            enemy.TakeDamage(damagePerTick);
            timeLastDamageDealt = Time.time;
        }
    }
}