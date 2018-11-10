using System;
using UnityEngine;

namespace Fusers
{
    public class TestTower : AbstractTower, ITower
    {

        new void Update()
        {
            Debug.Log("FirE");
            GameObject arrow = (GameObject)Resources.Load("Arrow");
            Instantiate(arrow);
            arrow.GetComponent<Arrow>().FireProjetile(new Vector3(25,25,0), transform.position);
        }
        public override void AddAugmentation(ElementAugment augment)
        {
            throw new NotImplementedException();
        }

        protected override float CalculateTowerAttackDamage()
        {
            throw new NotImplementedException();
        }

        protected override IAttack ConstructAttack()
        {
            throw new NotImplementedException();
        }
    }
}
