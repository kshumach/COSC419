using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	
    public static void HandleEnemyTurn()
    {
        foreach(GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            GameObject closest = World.findClosestPlayableCharacter(Enemy);
            int x = closest.GetComponent<Character>().isAt().GetComponent<Tile>().getX();
            int y = closest.GetComponent<Character>().isAt().GetComponent<Tile>().getY();

            int dx = (Enemy.GetComponent<Character>().isAt().GetComponent<Tile>().getX() - x);
            int dy = (Enemy.GetComponent<Character>().isAt().GetComponent<Tile>().getY() - y);

            int squaresMoved = dx + dy - 1;


            moveToClosestSquare(Enemy, closest, dx, dy);
            if (World.isnextTo(Enemy, closest))
            {
                Enemy.GetComponent<Character>().attack(Enemy, closest);
            }
            
        }
    }
    private static void moveToClosestSquare(GameObject Enemy, GameObject Friendly, float dx, float dy)
    {
        int x_moved =  Math.Abs(Enemy.GetComponent<Character>().movement * (dx / (Math.Abs(dx) + Math.Abs(dy)))) > Math.Min(Math.Abs(dx), Enemy.GetComponent<Character>().movement)
            ? (int)(Enemy.GetComponent<Character>().movement * (dx / (dx + dy))) 
            : (int) (Math.Abs(dx) > Enemy.GetComponent<Character>().movement ? Enemy.GetComponent<Character>().movement : dx);
        int y_moved = Math.Abs(Enemy.GetComponent<Character>().movement * (dy / (Math.Abs(dx) + Math.Abs(dy)))) > Math.Min(Math.Abs(dy), Enemy.GetComponent<Character>().movement)
            ? (int)(Enemy.GetComponent<Character>().movement * (dy / (dx + dy)))
            : (int)(Math.Abs(dy) > Enemy.GetComponent<Character>().movement ? Enemy.GetComponent<Character>().movement : dy);

        if (Math.Abs(y_moved) > 0)
        {
            y_moved = Enemy.GetComponent<Character>().movement - x_moved > Math.Abs(y_moved) ?
                y_moved :
                (y_moved / Math.Abs(y_moved)) * Enemy.GetComponent<Character>().movement - x_moved;
        }
        if (Math.Abs(dx) == 1 && Math.Abs(dy) == 1)
        {
            x_moved = (int)(1 * (dx / Math.Abs(dx)));
            y_moved = 0;
        }
        else
        {
            if (Math.Abs(dx) <= 1)
            {
                x_moved = 0;
            }
            if (Math.Abs(dy) <= 1)
            {
                y_moved = 0;
            }
        }

        Enemy.GetComponent<Character>().EnemyGoesTo(Enemy.GetComponent<Character>().isAt().GetComponent<Tile>()
            .all[Enemy.GetComponent<Character>().isAt().GetComponent<Tile>().getX() - x_moved][Enemy.GetComponent<Character>().isAt().GetComponent<Tile>().getY() - y_moved]);
    }
    
}
