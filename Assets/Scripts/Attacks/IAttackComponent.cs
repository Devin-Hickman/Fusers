using System.Collections.Generic;

public interface IAttackComponent
{
    /// <summary>
    /// Returns a list of status effects that can be used for created attack inside the component
    /// </summary>
    /// <returns></returns>
    List<IStatusEffect> GetStatusEffects();

    /// <summary>
    /// Performs the attack associated with the component
    /// </summary>
    void DoAttack(float x, float y, float z);
}