using System.Collections.Generic;
using UnityEngine;

namespace Fusers
{
    internal class ColliderRangeDetector : MonoBehaviour
    {
        public string layerToSearch;
        private List<string> layerstoSearch = null;
        private SpriteRenderer rangeIndicator;
        [SerializeField] private float searchRadius = 0;

        private void Awake()
        {
            rangeIndicator = this.GetComponent<SpriteRenderer>();
            rangeIndicator.transform.localScale = new Vector3(searchRadius * 1.5f, searchRadius * 1.5f, 0);
            rangeIndicator.enabled = false;
        }

        //Does this work to fix problem below? TODO: test
        /* private void OnValidate()
         {
             rangeIndicator.transform.localScale = new Vector3(searchRadius * 1.5f, searchRadius * 1.5f, 0);
         }*/

        private void Update()
        {
            //TODO: Move this outside of update function
            //rangeIndicator.transform.localScale = new Vector3(searchRadius * 1.5f, searchRadius * 1.5f, 0);
        }

        public void ConstructValues(float radius, string layer)
        {
            searchRadius = radius;
            layerToSearch = layer;

        }

        public Collider2D[] FindEnemiesInAttackRadius(float radius)
        {
            //Uses a layermask to filter colliders for enemy units only. Enemies must be on Enemy layer or else they will not be found
            //Can use this to add in camoflauge units. If the tower does not have a camoflague sensor, it will ignore that layer, but if
            // it does have that sensor it will use the layer
            //TODO: Add camoflauge trigger
            if (layerstoSearch == null)
            {
                int layerMask = 1 << LayerMask.NameToLayer(layerToSearch);
                return Physics2D.OverlapCircleAll(transform.position, searchRadius, layerMask);
            }
            else
            {
                int finalLayerMask = 0;
                foreach (string layer in layerstoSearch)
                {
                    int layerMask = 1 << LayerMask.NameToLayer(layer);
                    finalLayerMask = finalLayerMask | layerMask;
                }
                return Physics2D.OverlapCircleAll(transform.position, searchRadius, finalLayerMask);
            }
        }

        public void ShowRangeIndicator()
        {
            rangeIndicator.enabled = true;
        }

        public void HideRangeIndicator()
        {
            rangeIndicator.enabled = false;
        }
    }
}

