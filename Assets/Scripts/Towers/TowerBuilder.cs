using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusers;

public class TowerBuilder : MonoBehaviour {

    private bool buildMode;
    public bool BuildMode { get { return buildMode; } }

    static GameObject ghostTower = null;
    private string towerResourceName;


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
            ghostTower.transform.position = InputManager.GetInputPosition();
            ghostTower.GetComponent<AbstractTower>().ShowRangeIndicator();

            if (Input.GetMouseButtonDown(0))
            {
                buildMode = false;
                //TODO:Cast ray from position to determine if tower is being built on an invalid location

                GameObject realTower = Instantiate(Resources.Load(towerResourceName)) as GameObject;
                realTower.transform.position = ghostTower.transform.position;

                Destroy(ghostTower);

            }
        }
	}


    private GameObject InstantiateGhostTower(string towerFileName)
    {
        //TODO: Ghost towers shouldn't be able to attack enemies lol
        GameObject tmpTower = Instantiate(Resources.Load(towerFileName)) as GameObject;
        tmpTower.transform.localScale = new Vector3(4, 4, 1);

        return tmpTower;
    }

    private void OutputCannotBuyTower()
    {
        Debug.Log("Not enough cores to buy new tower");
    }

    public void AttemptBuildTower(string towerSpriteFileName)
    {
        Debug.Log("Building tower");
        towerResourceName = towerSpriteFileName;
        if (playerData.GetNormalCoresCount() >= 0)
        {
            buildMode = true;
            ghostTower = InstantiateGhostTower(towerSpriteFileName);
        }
        else
        {
            OutputCannotBuyTower();
        }

        
        // towerToBuild = Resoures.Load<Sprite>("Sprite/towerSpriteFileName");
        //Create a holographic model of the tower, that follows the player's mouse/finger

        //On second click create a real model of the tower in the player's mouse/finger position, snap to a grid
    }
}
