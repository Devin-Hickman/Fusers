using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusers;


public class SplashAttack : AbstractAttack, IAttack
{
    private float splashDamage;
    private float splashRadius = 0;
    private ColliderRangeDetector splashEnemyDetecter;


    public SplashAttack(float _splashDamage, float _radius)
    {
        splashDamage = _splashDamage;
        splashRadius = _radius;
    }

    void Awake()
    {

    }

    public float GetSplashDamage()
    {
        return splashDamage;
    }

    public override void PerformSpecialAction()
    {
        throw new NotImplementedException();
    }
}

public class SplitterAttacks : AbstractAttack, IAttack
{
    /// <summary>
    /// Splitter attacks are created after a splash attack lands, this ends the chain of attacks
    /// </summary>
    public override void PerformSpecialAction()
    {
        return;
    }
}

