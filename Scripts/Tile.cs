using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{

    // Use this for initialization
    private float x, y, z;
    public bool Selected = false;
    public GameObject[][] all;
    public void setAll(GameObject[][] all)
    {
        this.all = all;
    }

    public void deselect()
    {
        if (this.Selected)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        this.Selected = false;
    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && GameObject.Find("Cha_Knight").GetComponent<charSelect>().moving)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
            this.Selected = true;
            foreach (GameObject[] planes in this.all)
            {
                foreach (GameObject plane in planes)
                {
                    if (!plane.Equals(gameObject))
                    {
                        Debug.Log("ERE MATE");
                        plane.GetComponent<Tile>().deselect();
                    }
                }
            }
             
        }
    }
    void OnMouseEnter()
    {
        if (!this.Selected && GameObject.Find("Cha_Knight").GetComponent<charSelect>().moving)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
    void OnMouseExit()
    {
        if (!this.Selected && GameObject.Find("Cha_Knight").GetComponent<charSelect>().moving)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}

