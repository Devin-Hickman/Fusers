using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour {
    
    [SerializeField] protected float health;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected int damage;

    Transform[] pathPoints;
    Transform currentDestinationPoint;
    private int currentDestinationPointIndex = 0;
    private Vector3 startPosition;

    Rigidbody2D rb2d;
    private Vector3 targetDirection;

	// Use this for initialization
	void Start () {
        startPosition = this.transform.position;
        pathPoints = GameObject.Find("Enemy Path").GetComponentsInChildren<Transform>();
        currentDestinationPoint = pathPoints[currentDestinationPointIndex];
        Debug.Log(currentDestinationPoint.name);
        rb2d = GetComponent<Rigidbody2D>();

        onRoundStart();
	}
	
	// Update is called once per frame
	void Update () {

        Move();
    }

    private void Move()
    {
        rb2d.velocity = targetDirection * moveSpeed;
    }

    private void onRoundStart()
    {
        updateDestinationPoint();
    }

    public virtual void OnAttacked(float incomingDamage)
    {
        Debug.Log("Under attack");
        health -= incomingDamage;
        if(health < 0)
        {
            onDeath();
        }
    }

    private void reachedEnd()
    {
        //Deal 1 damage to player
        Destroy(this);
    }

    private void updateDestinationPoint()
    {
        currentDestinationPointIndex++;
        currentDestinationPoint = pathPoints[currentDestinationPointIndex];
        targetDirection = (currentDestinationPoint.position - transform.position).normalized;
        
    }

    private void onDeath()
    {
        Debug.Log("ENEMY SLAIN");
    }

    protected virtual void dropItemsOnDeath()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pathPoint")
        {

            updateDestinationPoint();
        }

        if (other.tag == "pathEnd")
        {
            Debug.Log("PLAYER DAMAGE TAKEN -1HP");
            transform.position = startPosition;
            currentDestinationPointIndex = 0;
            updateDestinationPoint();
            //reachedEnd();
        }
    }
}
