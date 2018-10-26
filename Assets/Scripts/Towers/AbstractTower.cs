using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

public abstract class AbstractTower : MonoBehaviour, IAugmentable  {

    [SerializeField] protected float attackRadius;
    [SerializeField] protected float attackDamage;
    [SerializeField] protected float attacksPerSecond;
    //rangeIndicator scale (radius) is dependent on attackRadius * 1.5
    private float lastAttackTime;
    private float attackCooldown; // = 1/attacksPerSecond
    private bool hasAttacked = false;
    [SerializeField] protected ElementType attackDamageType;

    [SerializeField] protected int costToPurchase;
    [SerializeField] protected int costToUpgrade;
    protected Sprite sprite;

    private ColliderRangeDetector enemiesInRangeDetector;

    void Awake()
    {
        enemiesInRangeDetector = this.GetComponentInChildren<ColliderRangeDetector>();
    }
	// Use this for initialization
	protected void Start () {
        attackCooldown = 1 / attacksPerSecond;

        Debug.Log(enemiesInRangeDetector.name);
        //Get the range indicator that is displayed for the tower and set disable it.
        //May need to be changed for different scaling on phones
        enemiesInRangeDetector.transform.localScale = new Vector3(attackRadius * 1.5f, attackRadius * 1.5f, 0);
        enemiesInRangeDetector.ConstructValues(attackRadius);
        enemiesInRangeDetector.HideRangeIndicator();
        
	}

	// Update is called once per frame
	void Update () {
        Collider2D[] enemiesInRange = enemiesInRangeDetector.FindEnemiesInAttackRadius();
        if(enemiesInRange.Length > 0)
        {
            AbstractEnemy enemy = enemiesInRange[0].gameObject.GetComponent<AbstractEnemy>();
            Debug.Log("ENEMY FOUND");
            DoAttack(enemy);
        }   
	}

    public void ShowRangeIndicator()
    {
        enemiesInRangeDetector.ShowRangeIndicator();
    }

    public void HideRangeIndicator()
    {
        enemiesInRangeDetector.HideRangeIndicator();
    }

    protected virtual void DoAttack(AbstractEnemy enemy)
    {
        
        if (!hasAttacked)
        {
            lastAttackTime = Time.time;
            enemy.OnAttacked(ConstructAttack());
            hasAttacked = true;
        }
        else if(Time.time > lastAttackTime + attackCooldown)
        {
            Debug.Log("Attack recharging");
            hasAttacked = false;
        }
    }

    public float GetDamage() { return attackDamage; }

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

    protected abstract IAttack ConstructAttack();

    protected abstract float CalculateTowerAttackDamage();
}
