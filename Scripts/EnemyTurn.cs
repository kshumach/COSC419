using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            foreach(GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                GameObject closest = World.findClosestPlayableCharacter(Enemy);
                int x = closest.GetComponent<Character>().isAt().GetComponent<Tile>().getX();
                int y = closest.GetComponent<Character>().isAt().GetComponent<Tile>().getX();

                int squaresMoved = (Enemy.GetComponent<Character>().isAt().GetComponent<Tile>().getX() - x)
                    + (Enemy.GetComponent<Character>().isAt().GetComponent<Tile>().getX() - y) - 1;

                if (squaresMoved >= Enemy.GetComponent<Character>().movement)
                {
                    this.moveToClosestSquare(Enemy, closest);
                }else if (squaresMoved > Enemy.GetComponent<Character>().movement)
                {
                    this.moveTowards(Enemy, closest);
                }
            }
        }
    }
    private void moveToClosestSquare(GameObject Enemy, GameObject Friendly)
    {
        
    }
    private void moveTowards(GameObject Enemy, GameObject Friendly)
    {

    }
}
