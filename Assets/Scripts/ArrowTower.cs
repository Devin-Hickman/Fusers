using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : AbstractTower {


    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
