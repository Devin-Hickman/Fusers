using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Attack
{
    private float damage;
    private bool isSplash = false;
    private float splashRadius = 0;

    private bool isDoT = false;
    private float DoTDamagePerTick = 0;
    private float DoTDuratoin = 0;

    private bool isStatus = false;
    private StatusEffect statusEffect = null;


    public void DoDamage()
    {

    }

    public void AddSplashEffect(float radius)
    {
        splashRadius = radius;
        isSplash = true;
    }

    public void SetDamage(float d)
    {
        damage = d;
    }

    public void AddDoTEffect(float damagerPerTick, float duration)
    {
        DoTDamagePerTick = damagerPerTick;
        DoTDuratoin = duration;
    }

    public void AddStatusEffect(StatusEffect s)
    {

    }


}

