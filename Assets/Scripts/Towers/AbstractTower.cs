using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

public abstract class AbstractTower : MonoBehaviour, IAugmentable  {

    [SerializeField] protected float attackRadius;
    [SerializeField] protected float attackDamage;
    [SerializeField] protected float attacksPerSecond;
    //rangeIndicator scale (radius) is dependent on attackRadius * 1.5
    GameObject rangeIndicator;
    private float lastAttackTime;
    private float attackCooldown; // = 1/attacksPerSecond
    private bool hasAttacked = false;
    protected ElementType attackDamageType;

    [SerializeField] protected int costToPurchase;
    [SerializeField] protected int costToUpgrade;
    protected Sprite sprite;

	// Use this for initialization
	void Start () {
        attackCooldown = 1 / attacksPerSecond;
        //Get the range indicator that is displayed for the tower and set disable it.
        rangeIndicator = GetComponentInChildren<SpriteRenderer>().gameObject;
        //May need to be changed for different scaling on phones
        rangeIndicator.transform.localScale = new Vector3(attackRadius * 1.5f, attackRadius * 1.5f, 0);
        rangeIndicator.SetActive(false);
        
	}

    public void ShowRangeIndicator()
    {
        rangeIndicator.SetActive(true);
    }

    public void HideRangeIndicator()
    {
        rangeIndicator.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        Collider2D[] enemiesInRange = FindEnemiesInAttackRadius();
        if(enemiesInRange.Length > 0)
        {
            AbstractEnemy enemy = enemiesInRange[0].gameObject.GetComponent<AbstractEnemy>();
            Debug.Log("ENEMY FOUND");
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
        //Uses a layermask to filter colliders for enemy units only. Enemies must be on Enemy layer or else they will not be found
        //Can use this to add in camoflauge units. If the tower does not have a camoflague sensor, it will ignore that layer, but if
        // it does have that sensor it will use the layer
        //TODO: Add camoflauge trigger
        int layerMask = 1 << LayerMask.NameToLayer("Enemy");
        return Physics2D.OverlapCircleAll(transform.position, attackRadius, layerMask);
    }

    int towerState = 0;
    public void SwapSprite()
    {
        switch (towerState)
        {
            case 0:
                this.GetComponent<SpriteRenderer>().color = Color.yellow;
                towerState = 1;
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                towerState = 0;
                break;
        }

    }


    public abstract void AddAugmentation(Augment augment);

    protected abstract float CalculateTowerAttackDamage();
}
