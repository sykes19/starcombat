using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawMesh : MonoBehaviour
{
    Mesh m;
    MeshFilter mf;
    // Use this for initialization
    void Start()
    {
        mf = GetComponent<MeshFilter>();
        m = new Mesh();
        mf.mesh = m;
        drawTriangle();
    }
    //This draws a triangle
    void drawTriangle()
    {
        //We need two arrays one to hold the vertices and one to hold the triangles
        Vector3[] VerteicesArray = new Vector3[4];
        int[] trianglesArray = new int[6];
        //lets add 3 vertices in the 3d space
        VerteicesArray[0] = new Vector3(0, 1, 0);
        VerteicesArray[1] = new Vector3(-1, 0, 0);
        VerteicesArray[2] = new Vector3(1, 0, 0);
        VerteicesArray[3] = new Vector3(-1, 1, 0);
        //define the order in which the vertices in the VerteicesArray should be used to draw the triangle
        trianglesArray[0] = 0;
        trianglesArray[1] = 1;
        trianglesArray[2] = 2;

        trianglesArray[3] = 3;
        trianglesArray[4] = 1;
        trianglesArray[5] = 0;
        //add these two triangles to the mesh
        m.vertices = VerteicesArray;
        m.triangles = trianglesArray;
    }
}
