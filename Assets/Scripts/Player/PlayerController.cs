using Fusers;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private PlayerData playerData;
    private ShopItems shop;

    public Text fireCoreCount;
    public Text waterCoreCount;
    public Text earthCoreCount;
    public Text airCoreCount;
    public Text normalCoreCount;

    private AbstractTower lastClickedTower;
    private AbstractEnemy lastClickedEnemy;
    IFocusable currentFocus;

    // Use this for initialization
    private void Start()
    {
        playerData = new PlayerData();
        shop = GameObject.Find("Shop").GetComponent<ShopItems>();
    }

    // Update is called once per frame
    private void Update()
    {
        ///Updates Focus of current object, from building, to tower, to enemy
        if (Input.GetMouseButtonDown(0))
        {
            GameObject clickedtarget = GameObjctClickedOn();
            if(clickedtarget != null)
            {
                MonoBehaviour[] list = clickedtarget.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour mb in list)
                {
                    if (mb is IFocusable)
                    {
                        ClearFocus(currentFocus);
                        currentFocus = (IFocusable)mb;
                        currentFocus.OnFocus();
                    }
                }
            }
            else
            {
                ClearFocus(currentFocus);
            }


            /*//Clicked on a tower, update ui to reflect tower stats
            if (clickedtarget.GetComponent<AbstractTower>() != null)
            {
                lastClickedTower = clickedtarget.GetComponent<AbstractTower>();
                lastClickedTower.SwapSprite();
            }

            if (clickedtarget.GetComponent<AbstractEnemy>() != null)
            {
                //Clicked on an enemy, update UI to reflect enemy stats
                lastClickedEnemy = clickedtarget.GetComponent<AbstractEnemy>();
                Debug.Log(lastClickedEnemy.name);
            }*/
        }

        purchaseAugment();
        updateCoreCountDisplay();
    }

    private void purchaseAugment()
    {
        ElementAugment augmentToBuy = null;
        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (ElementAugment e in shop.elementAugmentsForSale)
            {
                if (e.elementType == ElementType.FIRE)
                {
                    augmentToBuy = e;
                }
            }
            if (lastClickedTower != null && PlayerData.GetFireCoresCount() >= augmentToBuy.cost)
            {
                lastClickedTower.AddAugmentation(augmentToBuy);
            }
        }
    }

    private GameObject GameObjctClickedOn()
    {
        GameObject clickedObject = null;

        Camera cam = Camera.main;
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            clickedObject = hit.collider.gameObject;
        }

        return clickedObject;
    }

    //Event callbacks. Called on enemyDeath
    public static void addCorestoInventory(Core core)
    {
        PlayerData.AddCores(core);
        //  Debug.Log("Added " + core.Count + " " + core.CoreType + " to inventory");
    }

    public static void addCoresToInvetory(List<Core> coreList)
    {
        foreach (Core c in coreList)
        {
            PlayerData.AddCores(c);
        }
    }

    private void updateCoreCountDisplay()
    {
        airCoreCount.text = "AIR: " + PlayerData.GetAirCoresCount();
        fireCoreCount.text = "FIRE: " + PlayerData.GetFireCoresCount();
        waterCoreCount.text = "WATER: " + PlayerData.GetWaterCoresCount();
        earthCoreCount.text = "EARTH: " + PlayerData.GetEarthCoresCount();
        normalCoreCount.text = "NORMIES: " + PlayerData.GetNormalCoresCount();
    }

    private void ClearFocus(IFocusable f)
    {
        if (f != null)
        {
            f.OffFocus();
        }
    }
}