using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;


interface IEnemy
{
    void AddStatusEffect(StatusEffect effect);
    void AddStatusEffects(List<StatusEffect> effects);

    void OnAttacked(IAttack incomingAttack);
    void Move();
    void DoDeath();
}

