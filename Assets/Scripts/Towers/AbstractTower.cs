﻿using Fusers;
using UnityEngine;

public abstract class AbstractTower : MonoBehaviour, ITower, IFocusable
{

    [SerializeField] protected float attackRadius;
    [SerializeField] protected float attackDamage;
    [SerializeField] protected float attacksPerSecond;

    public GameObject arrow;

    //rangeIndicator scale (radius) is dependent on attackRadius * 1.5
    private float lastAttackTime;

    private float attackCooldown; // = 1/attacksPerSecond
    private bool hasAttacked = false;
    [SerializeField] protected ElementType attackDamageType;
    [SerializeField] protected int costToPurchase;
    [SerializeField] protected int costToUpgrade;
    protected Sprite sprite;

    private ColliderRangeDetector enemiesInRangeDetector;

    protected AbstractTower towerComponent;

    private void Awake()
    {
        towerComponent = GetComponent<AbstractTower>();
        enemiesInRangeDetector = this.GetComponentInChildren<ColliderRangeDetector>();
        enemiesInRangeDetector.ConstructValues(attackRadius, "Enemy");
    }

    // Use this for initialization
    protected virtual void Start()
    {
        attackCooldown = 1 / attacksPerSecond;

        //Get the range indicator that is displayed for the tower and set disable it.
        //May need to be changed for different scaling on phones
        enemiesInRangeDetector.transform.localScale = new Vector3(attackRadius * 1.5f, attackRadius * 1.5f, 0);
        enemiesInRangeDetector.ConstructValues(attackRadius, "Enemy");
        enemiesInRangeDetector.HideRangeIndicator();
    }

    // Update is called once per frame
    protected void Update()
    {
        Collider2D[] enemiesInRange = enemiesInRangeDetector.FindEnemiesInAttackRadius(attackRadius);
        if (enemiesInRange.Length > 0)
        {
            AbstractEnemy enemy = enemiesInRange[0].gameObject.GetComponent<AbstractEnemy>();
            Debug.Log("ENEMY FOUND");
            Shoot(enemy);
        }
    }

    public void EnableGhostMode()
    {
        towerComponent.enabled = false;
        SetTransparnecyOfSprite(100);
    }

    private void SetTransparnecyOfSprite(int transparnecy)
    {
        Color color = GetComponent<SpriteRenderer>().color;
        color.a = transparnecy;
        this.GetComponent<SpriteRenderer>().color = color;
    }

    public void DisableGhostMode()
    {
        towerComponent.enabled = true;
        SetTransparnecyOfSprite(255);
    }

    public void ShowRangeIndicator()
    {
        enemiesInRangeDetector.ShowRangeIndicator();
    }

    public void HideRangeIndicator()
    {
        enemiesInRangeDetector.HideRangeIndicator();
    }

    public virtual void Shoot(AbstractEnemy enemy)
    {
        if (!hasAttacked)
        {
            Debug.Log(this.name + "Is shooting");
            Instantiate(arrow, this.transform.position , this.transform.rotation);
            arrow.GetComponent<Arrow>().FireProjetile(enemy.GetEnemyPosition(), transform.position);
            lastAttackTime = Time.time;
            IAttack attack = ConstructAttack();
            enemy.OnAttacked(attack);
            hasAttacked = true;
        }
        else if (Time.time > lastAttackTime + attackCooldown)
        {
            hasAttacked = false;
        }
    }

    public float GetDamage()
    {
        return attackDamage;
    }

    private int towerState = 0;

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

    public abstract void AddAugmentation(ElementAugment augment);

    protected abstract IAttack ConstructAttack();

    protected abstract float CalculateTowerAttackDamage();

    public void AddTowerComponent(ITowerComponent towerComponent)
    {
        Debug.Log("Adding Tower Component");
        throw new System.NotImplementedException();
    }

    public bool Purchase(int money)
    {
        return money >= costToPurchase;
    }

    public void OnFocus()
    {
        Debug.Log("Focusing on : " + this.name);
        ShowRangeIndicator();
    }

    public void OffFocus()
    {
        Debug.Log("Lost Focus on : " + this.name);
        HideRangeIndicator();
    }
}