﻿using Fusers;

namespace Fusers
{
    public enum ElementType
    {
        FIRE,
        WATER,
        AIR,
        EARTH,
        NORMAL
    }
}

public class BaseAttack : AbstractAttack, IAttack
{
    public BaseAttack(float _damage, ElementType elementType)
    {
        damage = _damage;
        damageType = elementType;
    }
}