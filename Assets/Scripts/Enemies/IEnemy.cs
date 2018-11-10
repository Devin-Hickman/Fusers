using System.Collections.Generic;

public interface IEnemy
{
    void AddStatusEffect(IStatusEffect effect);

    void AddStatusEffects(List<IStatusEffect> effects);

    void OnAttacked(IAttack incomingAttack);

    void Move();

    void DoDeath();

    void TakeDamage(float damage);
}