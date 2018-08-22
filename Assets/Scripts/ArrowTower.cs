using System.Collections;
using System.Collections.Generic;
using Fusers;
using UnityEngine;

public class ArrowTower : AbstractTower {

    [SerializeField]
    private ElementAugment elementalAugment = null;

    public override void AddAugmentation(Augment augment)
    {
        if(augment is ElementAugment)
        {
            elementalAugment = (ElementAugment)augment;
            attackDamageType = elementalAugment.GetElementType();
        }
    }

    protected override float CalculateTowerAttackDamage()
    {
        return attackDamage;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
