using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ColliderRangeDetector : MonoBehaviour
{
    string layerToSearch;
    List<string> layerstoSearch = null;
    float searchRadius = 0;

    ColliderRangeDetector(string layer, float radius)
    {
        layerToSearch = layer;
        searchRadius = radius;
    }

    ColliderRangeDetector(List<string> layerList, float radius)
    {
        layerstoSearch = layerList;
        searchRadius = radius;
    }

    public Collider2D[] FindEnemiesInAttackRadius()
    {
        //Uses a layermask to filter colliders for enemy units only. Enemies must be on Enemy layer or else they will not be found
        //Can use this to add in camoflauge units. If the tower does not have a camoflague sensor, it will ignore that layer, but if
        // it does have that sensor it will use the layer
        //TODO: Add camoflauge trigger
        if(layerstoSearch == null)
        {
            int layerMask = 1 << LayerMask.NameToLayer(layerToSearch);
            return Physics2D.OverlapCircleAll(transform.position, searchRadius, layerMask);
        }
        else
        {
            int finalLayerMask = 0;
            foreach (string layer in layerstoSearch)
            {
                int layerMask = 1 << layerMask.NameToLayer(layer);
                finalLayerMask = finalLayerMask | layerMask;
            }
            return Physics2D.OverlapCircleAll(transform.position, searchRadius, finalLayerMask);
        }

    }

    public void ShowRangeIndicator()
    {
        rangeIndicator.SetActive(true);
    }

    public void HideRangeIndicator()
    {
        rangeIndicator.SetActive(false);
    }
}

