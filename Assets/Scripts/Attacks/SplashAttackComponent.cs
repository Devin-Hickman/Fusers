using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;


public class SplashAttackComponent : AbstractAttackComponent, IAttackComponent
{
    private float splashDamage;
    private float splashRadius = 0;
    ElementType splashDamageType;
    private ColliderRangeDetector splashEnemyDetecter;
    List<IStatusEffect> statusEffects = new List<IStatusEffect>();

    public void SetSplashValues(float d, float r, ElementType sdt)
    {
        splashDamage = d;
        splashRadius = r;
        splashDamageType = sdt;
    }

    private IAttack ConstructAttack()
    {
        return new SplitterAttack(splashDamage, splashDamageType);
    }

    public void AddStatusEffects(List <IStatusEffect> s)
    {
        statusEffects.AddRange(s);
    }

    public void DoAttack()
    {
        List<IEnemy> enemies = ColliderRangeDetector.FindEnemiesInAttackRadius(splashRadius).GetComponent<IEnemy>();
        foreach (IEnemy enemy in enemies)
        {
            IAttack attack = ConstructAttack();
            attack.AddStatusEffects(statusEffects);
            enemy.OnAttacked(attack);
        }
    }
}

public class SplitterAttack : AbstractAttack, IAttack
{
    float damage;
    ElementType damageType;

    public SplitterAttack(float d, ElementType dt)
    {
        damage = d;
        damageType = dt;
    }

}

