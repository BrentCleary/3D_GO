using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private GridClass grid;

    private void Start()
    {
        grid = new GridClass(50, 50, 4f, new Vector3(0, 0));

        HeatMapVisual heatMapVisual = new HeatMapVisual(grid, GetComponent<MeshFilter>());
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

    private class HeatMapVisual
    {
        private GridClass grid;

        public HeatMapVisual(GridClass grid,  MeshFilter meshFilter)
        {
            this.grid = grid;

            Vector3[] vertices;
            Vector2[] uv;
            int[] triangles;

            MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out vertices, out uv, out triangles);
        
            for(int x = 0; x < grid.GetWidth(); x++)
            {
                for(int y = 0; y < grid.GetHeight(); y++)
                {
                    int index = x * grid.GetHeight() + y;
                    Vector3 baseSize = new Vector3(1, 1) * grid.GetCellSize();
                    MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y), 0f, baseSize, Vector2.zero, Vector2.zero);
                }
            }

            Mesh mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.uv = uv;
            mesh.triangles = triangles;
        
        }
    }

}
