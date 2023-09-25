using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[Serializable]
    //used for build manager
public abstract class Tower : MonoBehaviour
{
    /*
    Different Tower Types
    Projectiles
    Sprays
    Beams
    Hit Scan
    Area of Effect
    Utility

    */

    

    [Header("References")]
    [SerializeField] protected Transform turretRotationPoint;
    [SerializeField] protected LayerMask enemyMask;
    [SerializeField] protected GameObject shot;
    [SerializeField] protected Transform barrel;


    [Header("Attributes")]
    [SerializeField] protected float range = 5f;
    [SerializeField] protected float rotationSpeed = 500f;
    [SerializeField] protected float fireRate = 1f;

    protected string towerName;
    protected int cost;
    protected GameObject prefab;

    protected Transform target;
    protected float timeBetweenShots;


    public Tower(string _name, int _cost, GameObject _prefab){
        towerName = _name;
        cost = _cost;
        prefab = _prefab;
    }

    public void setName(string newName){
        towerName = newName;
    }
    public string getName(){
        return towerName;
    }

    public void setCost(int amount){
        cost = amount;
    }
    public int getCost(){
        return cost;
    }

    public void setPrefab(GameObject thing){
        prefab = thing;
    }
    public GameObject getPrefab(){
        return prefab;
    }


    private void OnDrawGizmosSelected(){
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(this.transform.position,this.transform.forward,range);
    }


    protected bool CheckTargetInRange(){
        return Vector2.Distance(target.position,transform.position)<=range;
    }

    protected void FindTarget(){
        RaycastHit2D[] hits = Physics2D.CircleCastAll(this.transform.position,range,(Vector2)this.transform.position,0f,enemyMask);

        if(hits.Length >0){
            target = hits[0].transform;
        }

    }
    
    
}
