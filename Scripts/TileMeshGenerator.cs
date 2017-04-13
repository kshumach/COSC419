using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMeshGenerator : MonoBehaviour {

    // Use this for initialization
    public GameObject[][] planes;
	void Start () {
        planes = new GameObject[5][];
        for (int i = 0; i < 5; i++)
        {
            planes[i] = new GameObject[5];
            for (int j = 0; j < 5; j++)
            {
                planes[i][j] = GameObject.CreatePrimitive(PrimitiveType.Plane);
                planes[i][j].transform.position = new Vector3(11*i-10, 1.5F, 11*j-10);
                planes[i][j].AddComponent<Tile>();
                planes[i][j].GetComponent<Tile>().setAll(planes);
                planes[i][j].GetComponent<Tile>().isAt(i,j);
            }
        }
        planes[1][0].GetComponent<Tile>().setCharacter(GameObject.Find("Cha_Knight"));
        planes[3][1].GetComponent<Tile>().setCharacter(GameObject.Find("knight"));
        //ameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //ube.transform.position = new Vector3(0, 1.5F, 0);
    }
	
	// Update is called once per frame
	void Update () {

    }
    void OnMouseDown()
    {
        //gameObject.GetComponent<Tile>().OnMouseDown();
    }

    public GameObject[][] getPlanes()
    {
        return this.planes;
    }
}
