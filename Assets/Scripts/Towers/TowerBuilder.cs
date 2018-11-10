using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    private bool buildMode;

    private static GameObject ghostTower = null;
    private static GameObject createdTower = null;
    private string towerResourceName;

    // Update is called once per frame
    private void Update()
    {
        if (buildMode)
        {
            //Get mouse position, and have tower follow mouse position
            // Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // newPos.z = 0;
            createdTower.transform.position = InputManager.GetInputPosition();
            createdTower.GetComponent<AbstractTower>().ShowRangeIndicator();

            if (Input.GetMouseButtonDown(0))
            {
                if (CheckEligibleTowerPlacement(createdTower))
                {
                    PlaceTower();
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                Destroy(createdTower);
            }
        }
    }

    private void PlaceTower()
    {
        GameObject finalTower = Instantiate(createdTower);
        finalTower.name = "Elemental Tower";
        buildMode = false;
        finalTower.GetComponent<AbstractTower>().DisableGhostMode();
        Destroy(createdTower);
        //Cleanup. Remove unneeded gameobjects
        //Destroy(realTower);
        // Destroy(ghostTower);
    }

    private void OutputCannotBuyTower()
    {
        Debug.Log("Not enough cores to buy new tower");
    }

    /// <summary>
    /// UI Facing function. When the user clicks on the button check if they have enough money to purchase the tower, then
    /// create a ghost version of the tower they intend to purchase. Update handles the movement of the ghost tower and its placement
    /// </summary>
    /// <param name="towerToBuy"></param>
    public void ClickedOnBuyTower(GameObject towerToBuy)
    {
        if (towerToBuy.GetComponent<AbstractTower>().Purchase(PlayerData.GetNormalCoresCount()))
        {
            createdTower = Instantiate(towerToBuy);
            createdTower.name = "Ghost Tower";
            createdTower.GetComponent<AbstractTower>().EnableGhostMode();
            buildMode = true;
        }
        else
        {
            OutputCannotBuyTower();
        }
    }

    /// <summary>
    /// Checks if the tower can be placed in a valid location, not over any invalid locations in the map.
    ///
    /// </summary>
    private bool CheckEligibleTowerPlacement(GameObject tower)
    {
        Collider2D[] overlappedColliders = new Collider2D[0];
        Physics2D.OverlapCollider(tower.GetComponent<Collider2D>(), new ContactFilter2D(), overlappedColliders);
        return overlappedColliders.Length == 0;
    }
}