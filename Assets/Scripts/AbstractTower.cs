using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTower : MonoBehaviour {

    [SerializeField] protected float attackRadius;
    [SerializeField] protected float attackDamage;
    [SerializeField] protected float attacksPerSecond;
    private float lastAttackTime;
    private float attackCooldown; // = 1/attacksPerSecond
    private bool hasAttacked = false;
    

    [SerializeField] protected int costToPurchase;
    [SerializeField] protected int costToUpgrade;

	// Use this for initialization
	void Start () {
        attackCooldown = 1 / attacksPerSecond;
		
	}
	
	// Update is called once per frame
	void Update () {
        Collider2D[] enemiesInRange = findEnemiesInAttackRadius();
        if(enemiesInRange.Length > 0)
        {
            AbstractEnemy enemy = enemiesInRange[0].gameObject.GetComponent<AbstractEnemy>();
            attackEnemy(enemy);
        }   
	}

    protected virtual void attackEnemy(AbstractEnemy enemy)
    {
        if (!hasAttacked)
        {
            lastAttackTime = Time.time;
            enemy.OnAttacked(attackDamage);
            hasAttacked = true;
        }
        else if(Time.time > lastAttackTime + attackCooldown)
        {
            Debug.Log("Attack recharging");
            hasAttacked = false;
        }
    }

    protected Collider2D[] findEnemiesInAttackRadius()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Enemy");
        return Physics2D.OverlapCircleAll(transform.position, attackRadius, layerMask);
    }


}
