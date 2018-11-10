using System.Collections.Generic;
using UnityEngine;
using Unity;

namespace Fusers
{
    internal class FireSkillTree : SkillTree
    {
        private float splashRadius = 1;

        public float igniteDamage = 2;
        public float igniteDuration = 5;
        public bool spreadingFlameActive = false;

        private void Awake()
        {
            pointsForTierTwoUnlock = 5;
            pointsForTierThreeUnlock = 2;

            //TODO: Start all skills at 0 instead of max

            //Tier One Skills
            AbstractSkill damageBuff = new AbstractSkill(5, 5, 1, "Damage Buff");
            AbstractSkill rangeBuff = new AbstractSkill(5, 5, 1, "Range Buff");
            AbstractSkill attackSpeedBuff = new AbstractSkill(5, 5, 1, "Attack Speed Buff");

            skills.Add(damageBuff.GetName(), damageBuff);
            skills.Add(rangeBuff.GetName(), rangeBuff);
            skills.Add(attackSpeedBuff.GetName(), attackSpeedBuff);
            tierOneSkills.AddRange(new List<AbstractSkill> { damageBuff, rangeBuff, attackSpeedBuff });

            //Tiers Two Skills
            AbstractSkill splashskill = new AbstractSkill(2, 2, 2, "Splash Damage");
            AbstractSkill burnSkill = new AbstractSkill(2, 2, 2, "Ignition");

            skills.Add(splashskill.GetName(), splashskill);
            skills.Add(burnSkill.GetName(), burnSkill);
            tierTwoSkills.AddRange(new List<AbstractSkill> { splashskill, burnSkill });

            //Tier Three Skills
            AbstractSkill explosionSkill = new AbstractSkill(1, 1, 3, "Spreading Flame");
            skills.Add(explosionSkill.GetName(), explosionSkill);
            tierThreeSkills.Add(explosionSkill);
        }

        /// <summary>
        /// Returns a pecentage modifier to increase damage
        /// </summary>
        /// <returns>
        /// Returns damager percent modifier
        /// </returns>

        public override float GetDamageBoostPercentage()
        {
            return (float)(skills["Damage Buff"].GetCurrentLevel() * 10 / (float)100);
        }

        /// <summary>
        /// Returns a percentage modifier to increase range
        /// </summary>
        /// <returns></returns>

        public override float GetRangeBoostPercentage()
        {
            float s = (float)(skills["Range Buff"].GetCurrentLevel() * 5 / (float)100);
            return s;
        }

        /// <summary>
        /// Returns a percentage modifier to increase attack speed
        /// </summary>
        /// <returns></returns>

        public override float GetAttackSpeedBoostPercentage()
        {
            return (float)(skills["Attack Speed Buff"].GetCurrentLevel() * 5 / (float)100);
        }

        private void AddSplashAttackComponent(IAttack attack)
        {
            SplashAttackComponent tmpSplashAttack = new GameObject().AddComponent<SplashAttackComponent>();

            float splashAttackDamage = skills["Splash Damage"].GetCurrentLevel() * 1;
            float splashAttackRadius = skills["Splash Damage"].GetCurrentLevel() * 10;
            tmpSplashAttack.Construct(splashAttackDamage, splashAttackRadius, ElementType.FIRE);

            if (SkillActive("Ignition"))
            {
                tmpSplashAttack.AddStatusEffect(new Ignite(igniteDamage, igniteDuration));
            }
            attack.AddAttackComponent(tmpSplashAttack);
            Destroy(tmpSplashAttack.gameObject);
        }

        public override IAttack ModifyAttack(IAttack attack)
        {
            Debug.Log("Modifying Attack with Fire Tower Upgrades");
            if (SkillActive("Splash Damage"))
            {
                Debug.Log("Adding Splash Damange");
                AddSplashAttackComponent(attack);
            }

            if (SkillActive("Ignition"))
            {
                Debug.Log("Adding Ignitie Status Effect");
                attack.AddStatusEffect(new Ignite(igniteDamage, igniteDuration));
            }

            return attack;
        }

        private bool SkillActive(string skillName)
        {
            return skills[skillName].GetCurrentLevel() > 0;
        }

        //public override void IncreaseSkillLevel(string skillName, int increment, int tier) { base.IncreaseSkillLevel(skillName, increment, tier); }
    }
}