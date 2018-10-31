using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private playerData playerData;
    private ShopItems shop;

    public Text fireCoreCount;
    public Text waterCoreCount;
    public Text earthCoreCount;
    public Text airCoreCount;
    public Text normalCoreCount;

    AbstractTower lastClickedTower;
    AbstractEnemy lastClickedEnemy;

	// Use this for initialization
	void Start () {
        playerData = new playerData();
        shop = GameObject.Find("Shop").GetComponent<ShopItems>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject clickedtarget = GameObjctClickedOn();
            if(clickedtarget != null)
            {
                //Clicked on a tower, update ui to reflect tower stats
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
                }
            }
        }

        purchaseAugment();
        updateCoreCountDisplay();
    }

    private void purchaseAugment()
    {
        ElementAugment augmentToBuy = null;
        if (Input.GetKeyDown(KeyCode.F))
        {

            foreach(ElementAugment e in shop.elementAugmentsForSale)
            {
                if(e.elementType == ElementType.FIRE)
                {
                    augmentToBuy = e;
                }
            }
            if(lastClickedTower != null && playerData.GetFireCoresCount() >= augmentToBuy.cost)
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
        playerData.AddCores(core);
      //  Debug.Log("Added " + core.Count + " " + core.CoreType + " to inventory");
    }

    public static void addCoresToInvetory(List<Core> coreList)
    {
        foreach (Core c in coreList)
        {
            playerData.AddCores(c);
        }
    }

    private void updateCoreCountDisplay()
    {
        airCoreCount.text = "AIR: " + playerData.GetAirCoresCount();
        fireCoreCount.text = "FIRE: " + playerData.GetFireCoresCount();
        waterCoreCount.text = "WATER: " + playerData.GetWaterCoresCount();
        earthCoreCount.text = "EARTH: " + playerData.GetEarthCoresCount();
        normalCoreCount.text = "NORMIES: " + playerData.GetNormalCoresCount();
    }
}
