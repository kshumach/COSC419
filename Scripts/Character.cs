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

    public static void attack(Character c1, Character c2)
    {
        c2.health -= c1.damage;
        c1.hasAttacked = true;
    }

    public void setDefaults()
    {
        hasAttacked = false;
        hasMoved = false;
    }
}
