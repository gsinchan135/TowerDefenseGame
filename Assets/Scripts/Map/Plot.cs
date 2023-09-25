using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{

    private Tower tower;
    private static Plot previousSelection;

    private Color disappear = new Color(1.0f,1.0f,1.0f,0f); 
    private Color hover = new Color(1.0f,1.0f,1.0f,1.0f);


    public Tower getTower(){
        return tower;
    }

    public void setTower(Tower buildable){
        tower = buildable;
    }

    public void OnMouseDown(){
        if(previousSelection != null){
           previousSelection.GetComponent<SpriteRenderer>().color = disappear;
        }

        LevelManager.main.OpenMenu();
        LevelManager.main.SetCurrentPlot(this);
        this.GetComponent<SpriteRenderer>().color = hover;
        previousSelection = this;
    }
    
    public void OnMouseOver(){
        if(Input.GetMouseButton(1)){
            LevelManager.main.CloseMenu();
            previousSelection.GetComponent<SpriteRenderer>().color = disappear;
            previousSelection = this;
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
