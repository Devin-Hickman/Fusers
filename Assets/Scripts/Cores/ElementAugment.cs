using Fusers;
using UnityEngine;

[CreateAssetMenu(fileName = "EleAug", menuName = "ElementalAugment")]
public class ElementAugment : ScriptableObject
{
    public ElementType elementType;
    public ElementType coreTypeToPurchase;
    public int cost;
    public float bonusDmg;
    public float bonusRange;
    public float atkSpeedModifierPercent;
}