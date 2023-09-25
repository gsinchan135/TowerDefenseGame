using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    //[SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] public Tower[] towerOptionsSerializer;
    [SerializeField] public Transform parent;

    private Tower[] towerOptions;

   // private int currentTower = 0;

    private void Awake(){
        towerOptions = towerOptionsSerializer;
        main = this;
    }

    public void BuildTower(int selectedTower){

        Plot buildPlot = LevelManager.main.getCurrentPlot();
        Tower plotStatus = buildPlot.getTower();

        if(plotStatus != null) 
            return;
        
        Tower towerBuild = towerOptions[selectedTower];

        Tower tower = Instantiate(towerBuild,buildPlot.transform.position,Quaternion.identity,parent);
        buildPlot.setTower(tower);
        
    }

/*
    public Tower GetCurrentTower(){
        return towerOptions[currentTower];
    }

    public void SetSelectedTower(int selectedTower){
        currentTower = selectedTower;
    }
    */

}
