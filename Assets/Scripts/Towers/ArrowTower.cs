using System.Collections;
using System.Collections.Generic;
using Fusers;
using UnityEngine;

public class ArrowTower : AbstractTower {


    [SerializeField]
    private ElementAugment elementalAugment;


    public override void AddAugmentation(Augment augment)
    {
        if(augment is ElementAugment)
        {
            elementalAugment = (ElementAugment)augment;
            attackDamageType = elementalAugment.elementType;
            Debug.Log("Added "  + elementalAugment.elementType + " augment to the tower");
        }
    }

    protected override float CalculateTowerAttackDamage()
    {
        if (elementalAugment != null)
        {
            return attackDamage + elementalAugment.bonusDmg;
        }
        else
            return attackDamage;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
