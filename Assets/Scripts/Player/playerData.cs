using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;
using System;

public class playerData {
    private static readonly int maxCores = 999999;
   // private List<Core> playerCores = new List<Core>();
    private static Dictionary<ElementType, int> playerCores = new Dictionary<ElementType, int>();

    public playerData()
    {
        playerCores.Add(ElementType.AIR, 0);      //0
        playerCores.Add(ElementType.EARTH, 0);    //1
        playerCores.Add(ElementType.FIRE, 0);     //2
        playerCores.Add(ElementType.WATER, 0);    //3
        playerCores.Add(ElementType.NORMAL, 0);   //4
    }

    public static int GetAirCoresCount()
    {
        return playerCores[ElementType.AIR];
    }

    public static int GetEarthCoresCount()
    {
        return playerCores[ElementType.EARTH];
    }

    public static int GetFireCoresCount()
    {
        return playerCores[ElementType.FIRE];
    }

    public static int GetWaterCoresCount()
    {
        return playerCores[ElementType.WATER];
    }

    public static int GetNormalCoresCount()
    {
        return playerCores[ElementType.NORMAL];
    }

    public static  void AddCores(Core core)
    {
        ElementType eleType = core.CoreType;
        //Incrases the count of the core in the player list. Cannot be below 0 or exceed maxCoreCount
        if (playerCores.ContainsKey(eleType))
        {
            if(playerCores[eleType] + core.Count > maxCores)
            {
                playerCores[eleType] = maxCores;
            } else if (playerCores[eleType] + core.Count < 0)
            {
                playerCores[eleType] = 0;
            }
            else
            {
                playerCores[eleType] += core.Count;
            }

        }
        //Adds the core to list, should not occur
        else
        {
            Debug.Log("ADDED UNKNOWN CORE TO LIST");
            playerCores.Add(core.CoreType, core.Count);
        }
    }
}
