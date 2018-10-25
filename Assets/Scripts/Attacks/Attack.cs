using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;

public class Attack : AbstractAttack,  IAttack
{
    public Attack(float _damage, ElementType elementType)
    {
        damage = _damage;
        damageType = elementType;
    }

    /// <summary>
    /// Basic actions do not have any special actions associated with them
    /// </summary>
    public override void PerformSpecialAction()
    {
        return;
    }

}

