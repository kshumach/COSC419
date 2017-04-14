using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    GameObject Location;
    public int movement = 1;
    public bool hasMoved = false;
    public bool hasAttacked = false;
    public float health;
    public float damage;


	public void goesTo(GameObject p)
    {
        gameObject.transform.position = p.transform.position;
        Location = p;
    }

    public void attack(GameObject c1, GameObject c2)
    {
        c2.GetComponent<Character>().health -= c1.GetComponent<Character>().damage;
        c1.GetComponent<Character>().hasAttacked = true;
    }

    public void setDefaults()
    {
        hasAttacked = false;
        hasMoved = false;
    }
}
