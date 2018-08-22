using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

public abstract class AbstractTower : MonoBehaviour, IAugmentable  {

    [SerializeField] protected float attackRadius;
    [SerializeField] protected float attackDamage;
    [SerializeField] protected float attacksPerSecond;
    private float lastAttackTime;
    private float attackCooldown; // = 1/attacksPerSecond
    private bool hasAttacked = false;
    protected ElementType attackDamageType;
    

    [SerializeField] protected int costToPurchase;
    [SerializeField] protected int costToUpgrade;

	// Use this for initialization
	void Start () {
        attackCooldown = 1 / attacksPerSecond;
	}
	
	// Update is called once per frame
	void Update () {
        Collider2D[] enemiesInRange = FindEnemiesInAttackRadius();
        if(enemiesInRange.Length > 0)
        {
            AbstractEnemy enemy = enemiesInRange[0].gameObject.GetComponent<AbstractEnemy>();
            DoAttack(enemy);
        }   
	}

    protected virtual void DoAttack(AbstractEnemy enemy)
    {
        if (!hasAttacked)
        {
            lastAttackTime = Time.time;
            enemy.OnAttacked(CalculateTowerAttackDamage(), attackDamageType);
            hasAttacked = true;
        }
        else if(Time.time > lastAttackTime + attackCooldown)
        {
            Debug.Log("Attack recharging");
            hasAttacked = false;
        }
    }

    protected Collider2D[] FindEnemiesInAttackRadius()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Enemy");
        return Physics2D.OverlapCircleAll(transform.position, attackRadius, layerMask);
    }


    public abstract void AddAugmentation(Augment augment);

    protected abstract float CalculateTowerAttackDamage();
}
