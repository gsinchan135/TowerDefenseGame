using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed;

    private Transform target;
    private int pathIndex = 0;
    private Transform[] pathway;

    // Start is called before the first frame update
    void Start()
    {
        pathway = LevelManager.main.getPath();
        target = pathway[pathIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(target.position, this.transform.position) <=0.1f){
            pathIndex++;

            if(pathIndex == pathway.Length){
                EnemySpawner.onEnemyDestroyed.Invoke();
                Destroy(gameObject);
                return;
            }else{
                target = pathway[pathIndex];
            }
        }
    }

    private void FixedUpdate(){
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }
}
