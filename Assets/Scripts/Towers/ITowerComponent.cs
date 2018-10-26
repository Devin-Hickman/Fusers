using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public interface ITowerComponent
{
    /// <summary>
    /// Returns a float that amplifies or reduces the towers range by a %
    /// </summary>
    /// <returns></returns>
    float GetRangeModifier();
    /// <summary>
    /// Returns a float that amplifies or reduces the towers damage by a %
    /// </summary>
    /// <returns></returns>
    float GetDamageModifier();
    /// <summary>
    /// Returns a list of layer names that this tower is now able to target
    /// </summary>
    /// <returns></returns>
    List<String> GetTargetableLayers();
}

