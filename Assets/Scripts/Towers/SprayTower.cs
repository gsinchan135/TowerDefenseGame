using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayTower : Tower
{


    public SprayTower(string _name, int _cost, GameObject _prefab):base(_name,_cost,_prefab){
        name = _name;
        cost = _cost;
        prefab = _prefab;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
