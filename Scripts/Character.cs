using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    GameObject Location;
    public int movement = 1;
    public bool isEnemy;
    public float health = 10f;
    public float damage = 10f;
    public bool hasMoved = false;
    public bool hasAttacked = false;
    public float armor = 10f;
    public float totalHp = 10f;

    public void attack(GameObject c1, GameObject c2)
    {
        c2.GetComponent<Character>().health -= c1.GetComponent<Character>().damage * getAppliedDamagePercent(c1);
        c1.GetComponent<Character>().hasAttacked = true;
    }

    public float getAppliedDamagePercent(GameObject c)
    {
        float arm = c.GetComponent<Character>().armor;
        return (1 - (armor/(armor+50)));
    }

    public GameObject isAt()
    {
        return this.Location;
    }
    public void EnemyGoesTo(GameObject p)
    {
        gameObject.transform.position = p.transform.position;
        Location.GetComponent<Tile>().setCharacter(null);
        p.GetComponent<Tile>().setCharacter(gameObject);
        Location = p;
    }
	public void goesTo(GameObject p)
    {
        gameObject.transform.position = p.transform.position;
        Location = p;
        // Debug.Log(this + ", Location: " + p.GetComponent<Transform>().position);
    }

    public void setDefaults()
    {
        hasAttacked = false;
        hasMoved = false;
    }
}
