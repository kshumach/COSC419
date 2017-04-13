using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
{

    // Use this for initialization
    private int x, y;
    public bool Selected = false;
    public GameObject character = null;
    public GameObject[][] all;
    private bool isMoving = false;
    private GameObject active = null;

    public void setActive(GameObject newActive)
    {
        this.active = newActive;
        

    }
    public void showMovement()
    {
        Color change;
        GameObject moveChar;
        if (this.isMoving)
        {
            change = Color.white;
            moveChar = null;
            this.isMoving = false;
        } else
        {
            change = Color.blue;
            moveChar = this.getChar();
            this.isMoving = true;
        }
        if (this.hasCharacter())
       {
            World.showMovement(this.all, this.x, this.y, change, moveChar);
        }
    }
    public void move()
    {
        Debug.Log(gameObject);
        Debug.Log(active.GetComponent<Character>());

        this.active.GetComponent<Character>().goesTo(gameObject);
        this.setCharacter(active);
        World.clearTiles(all, this.getChar(), x, y);
        character.GetComponent<Character>().hasMoved = true;
    }
    public void isAt(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public void setCharacter(GameObject newcharacter)
    {
        this.character = newcharacter;
    }
    public bool hasCharacter()
    {
        return (this.character != null);
    }
    public GameObject getChar()
    {
        return this.character;
    }
    public void setAll(GameObject[][] all)
    {
        this.all = all;
    }
    void OnMouseDown()
    {
        if (World.getActivePlayer() == GameObject.Find("Cha_Knight") && !World.getActivePlayer().GetComponent<Character>().hasMoved)
        {
            if (this.active == null)
            {
                this.showMovement();
            }
            else
            {
                this.isMoving = false;
                this.move();
            }
        }
        
    }
    
}

