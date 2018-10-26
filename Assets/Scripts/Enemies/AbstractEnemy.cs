using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fusers;
using System;

public abstract class AbstractEnemy : MonoBehaviour, IEnemy {

    [Serializable]
    public class EnemyDeathEvent : UnityEvent<Core> { };
    public EnemyDeathEvent onDeathEvent;
    
    [SerializeField] protected float health;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected int damage;

    [SerializeField] protected ElementType armorType;
    [SerializeField] protected int armor;

    Core[] cores = new Core[] { new Core(ElementType.AIR), new Core(ElementType.EARTH), new Core(ElementType.FIRE), new Core(ElementType.WATER), new Core(ElementType.NORMAL) };

    Transform[] pathPoints;
    Transform currentDestinationPoint;
    private int currentDestinationPointIndex = 0;
    private Vector3 startPosition;

    Rigidbody2D rb2d;
    private Vector3 targetDirection;

    private List<StatusEffect> statusEffects = new List<StatusEffect>();
    protected List<ElementType> elementalWeaknesses = new List<ElementType>();
    protected List<ElementType> elementalVulnerabilities = new List<ElementType>();

	// Use this for initialization
	 void Start () {
        startPosition = this.transform.position;
        pathPoints = GameObject.Find("Enemy Path").GetComponentsInChildren<Transform>();
        currentDestinationPoint = pathPoints[currentDestinationPointIndex];
        rb2d = GetComponent<Rigidbody2D>();
        OnRoundStart();

        onDeathEvent.AddListener(PlayerController.addCorestoInventory);
    }
	
	// Update is called once per frame
	void Update () {

        Move();
        
    }

    private void DoStatusEffects()
    {
        foreach(StatusEffect s in statusEffects)
        {
            s.DoStatusEffect(this);
        }
    }

    public void AddStatusEffects(List<StatusEffect> effects)
    {
        statusEffects.AddRange(effects);
    }


    public void AddStatusEffect(StatusEffect effect)
    {
        statusEffects.Add(effect);
    }

    public void Move()
    {
        rb2d.velocity = targetDirection * moveSpeed;
    }

    private void OnRoundStart()
    {
        UpdateDestinationPoint();
    }

    public virtual void OnAttacked(IAttack incomingAttack)
    {
        Debug.Log("Under attack");
        incomingAttack.AddInvalidTarget(this);
        AddStatusEffects(incomingAttack.GetStatusEffects());

        health -= AdjustIncomingDamage(incomingAttack.GetDamage(), incomingAttack.GetDamageType());

        incomingAttack.PerformSpecialAction();

        if(health < 0)
        {
            DoDeath();
        }

        float AdjustIncomingDamage(float damage, ElementType damageType)
        {
            if (elementalVulnerabilities.Contains(damageType))
            {
                damage *= 1.25f;
            } else if (elementalWeaknesses.Contains(damageType))
            {
                damage /= 1.25f;
            }
            return damage;
        }
    }


    private void ReachedEnd()
    {
        //Deal 1 damage to player
        Destroy(this);
    }

    private void UpdateDestinationPoint()
    {
        currentDestinationPointIndex++;
        currentDestinationPoint = pathPoints[currentDestinationPointIndex];
        targetDirection = (currentDestinationPoint.position - transform.position).normalized;
        
    }

    public void DoDeath()
    {
        OnDeath();
    }

    private void OnDeath()
    {
        Debug.Log("ENEMY SLAIN");
        Core itemDropped = itemsDroppedOnDeath();
        onDeathEvent.Invoke(itemDropped);
        Destroy(this.gameObject);
    }

    protected virtual Core itemsDroppedOnDeath()
    {
        Core c = cores[UnityEngine.Random.Range(0, cores.Length)];
        c.Count = UnityEngine.Random.Range(0, 3);
        return c;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pathPoint")
        {
            UpdateDestinationPoint();
        }

        if (other.tag == "pathEnd")
        {
            Debug.Log("PLAYER DAMAGE TAKEN -1HP");
            transform.position = startPosition;
            currentDestinationPointIndex = 0;
            UpdateDestinationPoint();
            //reachedEnd();
        }
    }

}
