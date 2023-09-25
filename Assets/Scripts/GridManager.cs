using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Tilemap interactiveMap;

    //private Vector3Int previousMousePos = new Vector3Int();
    private Grid grid;


    Color highlight = new Color(1.0f,1.0f,1.0f,0.2f);
    Color unselected = new Color(1.0f,1.0f,1.0f,1.0f);

    // Start is called before the first frame update
    void Start() {
        grid = gameObject.GetComponent<Grid>();
    }

/*
    // Update is called once per frame
    void Update() {
        // Mouse over -> highlight tile
        Vector3Int mousePos = GetMousePosition();
        //Debug.Log(mousePos);
        if (!mousePos.Equals(previousMousePos)) {
            interactiveMap.SetTileFlags(previousMousePos,TileFlags.None);
            interactiveMap.SetColor(previousMousePos, unselected); // Remove old hoverTile
            interactiveMap.SetTileFlags(mousePos,TileFlags.None);
            interactiveMap.SetColor(mousePos, highlight);
            previousMousePos = mousePos;
        }

        
        // Left mouse click -> add path tile
        if (Input.GetMouseButton(0)) {
            //LevelManager.ToggleMenu();
        }


        // Right mouse click -> remove path tile
        if (Input.GetMouseButton(1)) {
            pathMap.SetTile(mousePos, null);
        }
        
        
    }
*/
    Vector3Int GetMousePosition () {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}
