using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower ballistaPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }


    private void OnMouseDown()
    {
        if(isPlaceable)
        {
            bool isPlaced = ballistaPrefab.CreateTower(ballistaPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}