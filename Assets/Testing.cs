using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private GridClass grid;

    private void Start()
    {
        grid = new GridClass(20, 10, 10f, Vector3.zero);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 500);
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    
    }

}
