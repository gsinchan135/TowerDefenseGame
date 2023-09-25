using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public Animator animatorSerializer;
    [SerializeField] public Transform startPointSerializer;
    [SerializeField] public Transform[] pathSerializer;

    private Transform startPoint;
    private Transform[] path;
    

    private static Animator anim;
    private static bool isMenuOpen = true;

    public static LevelManager main;

    private static Plot currentPlot;

    private int money;

    public Transform getStartPoint(){
        return startPoint;
    }

    public Transform[] getPath(){
        return path;
    }

    public int getMoney(){
        return money;
    }

    public Plot getCurrentPlot(){
        return currentPlot;
    }

    public void SetCurrentPlot(Plot plot){
        currentPlot = plot;
    }
    

    //left clicking a tile should set MenuOpen(in the animator) to true
    //should not be a toggle
    //have a second method for right clicking to set MenuOpen(in the animator) to false, to close menu
    public static void ToggleMenu(){
        isMenuOpen = !isMenuOpen;
        anim.SetBool("MenuOpen",isMenuOpen);
    }

    public void OpenMenu(){
        anim.SetBool("MenuOpen",true);
    }

    public void CloseMenu(){
        anim.SetBool("MenuOpen",false);
    }

    private void Awake(){
        main = this;
    }
    

    private void Start(){
        startPoint = startPointSerializer;
        path = pathSerializer;
        anim = animatorSerializer;
        money = 100;
    }

    public void IncreaseMoney(int amount){
        money+= amount;
    }

    public bool BuyTower(int amount){
        if(amount <= money){

            money -= amount;
            return true;
        }
        else{
            Debug.Log("You broke");
            return false;
        }
    }
    
}
