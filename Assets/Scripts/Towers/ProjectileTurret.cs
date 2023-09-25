using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ProjectileTurret : Tower
{
    
    public ProjectileTurret(string _name, int _cost, GameObject _prefab):base(_name,_cost,_prefab){
        name = _name;
        cost = _cost;
        prefab = _prefab;
    }


    public float getRange(){
        return range;
    }

    // Update is called once per frame
    private void Update()
    {
        if(target == null){
            FindTarget();
            return;
        }

        RotateToTarget();

        if(!CheckTargetInRange()){
            //resets target to null when furthest enemy along the path is no longer in range
            target=null;
        }else{
            timeBetweenShots += Time.deltaTime;

            if(timeBetweenShots >= 1f/fireRate){
                Shoot();
                timeBetweenShots = 0f;
            }
        }

    }

    private void Shoot(){
        //instantiates generic game object
        GameObject bulletObj = Instantiate(shot,barrel.position,Quaternion.identity);
        //converts game object to appropriate ammo type
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        //calls ammo types SetTarget method to attack
        bulletScript.SetTarget(target);
    }

/*
    private void OnDrawGizmosSelected(){
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(this.transform.position,this.transform.forward,range);
    }


    protected bool CheckTargetInRange(){
        return Vector2.Distance(target.position,transform.position)<=range;
    }

    protected void FindTarget(){
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position,range,(Vector2)transform.position,0f,enemyMask);

        if(hits.Length >0){
            target = hits[0].transform;
        }

    }

*/
    protected void RotateToTarget(){

        //enemy position - turret postion * Rad2Deg to get the turret to face the angle of the enemy
        float angle = Mathf.Atan2(target.position.y-transform.position.y,target.position.x-transform.position.x)*Mathf.Rad2Deg-90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f,0f,angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation,targetRotation,rotationSpeed*Time.deltaTime);
    }
    
    
}
