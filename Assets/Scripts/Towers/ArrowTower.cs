﻿using Fusers;
using UnityEngine;
using Unity;

public class ArrowTower : AbstractTower
{
    [SerializeField]
    private ElementAugment elementalAugment;

    private new void Start()
    {
        base.Start();
        attackDamageType = ElementType.NORMAL;
    }

    public override void AddAugmentation(ElementAugment augment)
    {
        if (augment is ElementAugment)
        {
            elementalAugment = (ElementAugment)augment;
            attackDamageType = elementalAugment.elementType;
            Debug.Log("Added " + elementalAugment.elementType + " augment to the tower");
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

    protected override IAttack ConstructAttack()
    {
        return new BaseAttack(attackDamage, attackDamageType);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}