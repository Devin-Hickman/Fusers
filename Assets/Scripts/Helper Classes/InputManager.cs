using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;
using UnityEngine;

class InputManager
{

    public static Vector3 GetInputPosition()
    {
        //TODO: Add logic to determine what system user is on
         Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         newPos.z = 0;
        return newPos;
    }
}


