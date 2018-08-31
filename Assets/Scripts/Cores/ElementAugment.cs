using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

[CreateAssetMenu(fileName = "EleAug", menuName = "ElementalAugment")]
public class ElementAugment : Augment {


    public ElementType elementType;
    public ElementType coreTypeToPurchase;
    public int cost;
    public float bonusDmg;
    public float bonusRange;
    public float atkSpeedModifierPercent;


}
