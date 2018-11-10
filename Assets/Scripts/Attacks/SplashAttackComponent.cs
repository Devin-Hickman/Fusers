using Fusers;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class SplashAttackComponent : AbstractAttackComponent, IAttackComponent
{
    private float splashDamage;
    private float splashRadius = 0;
    private ElementType splashDamageType;
    private GameObject splashAttackObject;
    private ColliderRangeDetector detector;
    private List<IStatusEffect> statusEffects = new List<IStatusEffect>();

    private void Awake()
    {
        splashAttackObject = (GameObject)Instantiate(Resources.Load("Splash Attack Component"));
        detector = splashAttackObject.GetComponent<ColliderRangeDetector>();
    }

    public void Construct(float d, float r, ElementType sdt)
    {
        splashDamage = d;
        splashRadius = r;
        detector.ConstructValues(splashRadius, "Enemy");
        splashDamageType = sdt;
    }

    private IAttack ConstructAttack()
    {
        return new SplitterAttack(splashDamage, splashDamageType);
    }

    public void AddStatusEffect(IStatusEffect s)
    {
        statusEffects.Add(s);
    }

    public void AddStatusEffects(List<IStatusEffect> s)
    {
        statusEffects.AddRange(s);
    }

    public override void DoAttack(float x, float y, float z)
    {
        Vector3 originOfAttack = new Vector3(x, y, z);
        splashAttackObject.transform.position = originOfAttack;
        Collider2D[] enemies = detector.FindEnemiesInAttackRadius(splashRadius);
        foreach (Collider2D enemyCol in enemies)
        {
            Debug.Log("Doing Splash Attack Component");
            IEnemy enemy = enemyCol.GetComponent<IEnemy>();
            IAttack attack = ConstructAttack();
            attack.AddStatusEffects(statusEffects);
            enemy.OnAttacked(attack);
        }
        Destroy(splashAttackObject);
    }
}

public class SplitterAttack : AbstractAttack, IAttack
{
    public SplitterAttack(float d, ElementType dt)
    {
        damage = d;
        damageType = dt;
    }
}