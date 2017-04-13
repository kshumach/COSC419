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
        if (this.hasCharacter()) {
            all[this.x][this.y].GetComponent<Renderer>().material.color = change;
            for (int i = 0; i <= this.character.GetComponent<charSelect>().movement; i++)
            {
                for (int j = 0; j <= this.character.GetComponent<charSelect>().movement; j++)
                {
                    if (i + j <= this.character.GetComponent<charSelect>().movement)
                    {
                        if (this.x + i < all.Length)
                        {
                            if (this.y + j < all.Length)
                            {
                                all[this.x + i][this.y + j].GetComponent<Renderer>().material.color = change;
                                all[this.x + i][this.y + j].GetComponent<Tile>().setActive(this.getChar());
                            }
                            if (this.y - j >= 0)
                            {
                                all[this.x + i][this.y - j].GetComponent<Renderer>().material.color = change;
                                all[this.x + i][this.y - j].GetComponent<Tile>().setActive(this.getChar());
                            }
                        }
                        if (this.x - i >= 0)
                        {
                            if (this.y + j < all.Length)
                            {
                                all[this.x - i][this.y + j].GetComponent<Renderer>().material.color = change;
                                all[this.x - i][this.y + j].GetComponent<Tile>().setActive(this.getChar());
                            }
                            if (this.y - j >= 0)
                            {
                                all[this.x - i][this.y - j].GetComponent<Renderer>().material.color = change;
                                all[this.x - i][this.y - j].GetComponent<Tile>().setActive(this.getChar());
                            }
                        }
                    }
                }
                    
            }
        }
    }
    public void move()
    {
        this.active.transform.position = gameObject.transform.position;
        this.setCharacter(active);

        for (int i = 0; i < all.Length; i++)
        {
            for (int j = 0; j < all.Length; j++)
            {
                //Debug.Log(all[i][j].GetComponent<Tile>().x + "," + all[i][j].GetComponent<Tile>().y);
                if (all[i][j].GetComponent<Tile>().getChar() == this.getChar() && (this.x != i || this.y != j))
                {

                    all[i][j].GetComponent<Tile>().setCharacter(null);
                }

                all[i][j].GetComponent<Tile>().setActive(null);
                all[i][j].GetComponent<Renderer>().material.color = Color.white;
            }
        }
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
        Debug.Log(x + "," + y + "CHECKING Char:" + this.getChar() + "CHECKING ACTIVE:" + this.active);

        if (this.active == null)
        {
            this.showMovement();
        } else
        {
            this.isMoving = false;
            this.move();
        }

    }
    
}

