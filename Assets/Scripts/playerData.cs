using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

public class playerData {
    private readonly int maxCores = 999999;
    private Dictionary<ElementType, int> playerCores;

    private void InitiliazePlayerCores()
    {
        foreach (ElementType val in System.Enum.GetValues(typeof(ElementType)))
        {
            playerCores.Add(val, 0);
        }
    }

    public void AddCores(ElementType core, int count)
    {   
        if(playerCores[core] + count > maxCores)
        {
            playerCores[core] = maxCores;
        }
        else if (playerCores[core] + count < 0)
        {
            playerCores[core] = 0;
        }
        else
        {
            playerCores[core] += count;
        }



    }
}
