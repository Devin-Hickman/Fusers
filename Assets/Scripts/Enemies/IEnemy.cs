using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;


public interface IEnemy
{
    void AddStatusEffect(IStatusEffect effect);
    void AddStatusEffects(List<IStatusEffect> effects);

    void OnAttacked(IAttack incomingAttack);
    void Move();
    void DoDeath();
    void TakeDamage(float damage);
}

