using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public Rigidbody2D bulletRB;
    [SerializeField] public Transform rotationPoint;
    [SerializeField] public GameObject impact;


    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;

    private Transform target;

    public void SetTarget(Transform _target){
        target = _target;
    }

    private void FixedUpdate(){
        if(!target)
            return;

        RotateToTarget();
        Vector2 direction = (target.position-transform.position).normalized;

        bulletRB.velocity = direction * bulletSpeed;        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        Instantiate(impact, this.transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

    protected void RotateToTarget(){

        //enemy position - turret postion * Rad2Deg to get the turret to face the angle of the enemy
        float angle = Mathf.Atan2(target.position.y-transform.position.y,target.position.x-transform.position.x)*Mathf.Rad2Deg+180;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f,0f,angle));
        rotationPoint.rotation = Quaternion.RotateTowards(rotationPoint.rotation,targetRotation,99999);
    }

    //destroys bullets that miss and leave cameras visibility
    void OnBecameInvisible(){
        if(gameObject != null)
            Destroy(gameObject);
    }
}
