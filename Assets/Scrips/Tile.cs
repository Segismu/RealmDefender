using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower ballistaPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown()
    {
        if(gridManager.GetNode(coordinates).isWalkable && !pathfinder.willBlockPath(coordinates))
        {
            bool isSuccessful = ballistaPrefab.CreateTower(ballistaPrefab, transform.position);

            if(isSuccessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyRecivers();
            }
        }
    }
}