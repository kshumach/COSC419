using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charSelect : MonoBehaviour {

    public bool moving = false;

    void Awake()
    {
       
    }

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            if (!moving )
                moving = true;
            else
            {
                Vector3 newPos = new Vector3(-1, -100, -1);
                GameObject[][] planes = Camera.main.GetComponent<TileMeshGenerator>().planes;
                for(int i = 0; i < planes.Length; i++)
                {
                    for(int j = 0; j < planes[i].Length; j++)
                    {
                        if (planes[i][j].GetComponent<Tile>().Selected)
                        {
                            Debug.Log("here " + i + " " + j);
                            newPos = planes[i][j].transform.position;
                        }
                    }
                }

                if (!newPos.Equals(new Vector3(-1, -100, -1)))
                    gameObject.transform.position = newPos;

                moving = false;
            }
        }
	}
}
