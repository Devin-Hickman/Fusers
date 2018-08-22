using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

public class Core : ScriptableObject {

    private ElementType coreType;

    public ElementType CoreType
    {
        get
        {
            return coreType;
        }

        set
        {
            coreType = value;
        }
    }
}
