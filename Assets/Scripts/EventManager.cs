using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

public class EventManager : MonoBehaviour {

    public delegate void deathAction();
    public static event deathAction onDeathEvent;


}
