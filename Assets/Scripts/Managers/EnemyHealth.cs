using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int moneyGained = 100;

    private bool isDestroyed = false; //stops extra calls to onEnemyDestroyed, when 2 bullets hit around the same time on last hp

    public void TakeDamage(int damage){
        hitPoints -= damage;

        //dead
        if(hitPoints<=0 && !isDestroyed){
            EnemySpawner.onEnemyDestroyed.Invoke();
            LevelManager.main.IncreaseMoney(moneyGained);
            isDestroyed = true;
            Destroy(gameObject);
        }
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
