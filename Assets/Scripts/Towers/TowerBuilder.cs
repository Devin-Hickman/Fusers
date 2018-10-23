using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

public class TowerBuilder : MonoBehaviour {

    private bool buildMode;
    public bool BuildMode { get { return buildMode; } }
    GameObject towerToBuild;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (buildMode)
        {
            //Get mouse position, and have tower follow mouse position
            // Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // newPos.z = 0;
            towerToBuild.transform.position = InputManager.GetInputPosition();
            towerToBuild.GetComponent<AbstractTower>().ShowRangeIndicator();

            if (Input.GetMouseButtonDown(0))
            {
                buildMode = false;
                InstantiateTower("");
                towerToBuild.GetComponent<AbstractTower>().HideRangeIndicator();
            }
        }
        towerToBuild.GetComponent<AbstractTower>().HideRangeIndicator();
	}

    private void InstantiateTower(string towerFileName)
    {
       GameObject tower = (GameObject) Instantiate(Resources.Load("Tower"));
        tower.transform.position = towerToBuild.transform.position;
        
    }

    public void buildTower(string towerSpriteFileName)
    {
        if (playerData.GetNormalCoresCount() > 10)
        {
            buildMode = true;
            towerToBuild = new GameObject("towerBlueprint");
            towerToBuild.AddComponent<SpriteRenderer>();
            towerToBuild.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("baseTower");
            towerToBuild.transform.localScale = new Vector3(4, 4, 1);
        }

        
        // towerToBuild = Resoures.Load<Sprite>("Sprite/towerSpriteFileName");
        //Create a holographic model of the tower, that follows the player's mouse/finger

        //On second click create a real model of the tower in the player's mouse/finger position, snap to a grid
    }
}
