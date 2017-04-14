using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour {

    public static int turnCounter = 1;
    private static GameObject activePlayer = null;
    private static GameObject player = null;
    private static GameObject enemy = null;
    public bool end = false;

    void Awake()
    {
        player = GameObject.Find("Cha_Knight");
        enemy = GameObject.Find("knight");
        activePlayer = GameObject.Find("Cha_Knight");
    }

    void Update()
    {
        if (player.GetComponent<Character>().health <= 0 || enemy.GetComponent<Character>().health <= 0)
        {
            Debug.Log("Game Over: " + (player.GetComponent<Character>().health <= 0 ? "Player lost" : "Player Won"));
            end = true;
            if(player.GetComponent<Character>().health <= 0)
            {
                GameObject.Find("End").GetComponent<Text>().text = "You Lose.";
                GameObject.Find("End").GetComponent<Text>().color = Color.red;
            } else
            {
                GameObject.Find("End").GetComponent<Text>().text = "You Won!";
                GameObject.Find("End").GetComponent<Text>().color = Color.blue;
            }
        }
        if(turnCounter%2 == 1)
        {
            if (nextTo(player, enemy))
            {
                Debug.Log("They are next to");
                if (!activePlayer.GetComponent<Character>().hasAttacked)
                    GameObject.Find("Attack").GetComponent<Button>().interactable = true;
                else
                    GameObject.Find("Attack").GetComponent<Button>().interactable = false;
            }
            else
            {
                GameObject.Find("Attack").GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            GameObject.Find("Attack").GetComponent<Button>().interactable = false;
        }
        
        
    }

    public bool nextTo(GameObject g1, GameObject g2)
    {
        
        bool x = Math.Abs((int) (g1.GetComponent<Character>().isAt().GetComponent<Tile>().getX() - g2.GetComponent<Character>().isAt().GetComponent<Tile>().getX())) <= 1;
        bool y = Math.Abs((int)(g1.GetComponent<Character>().isAt().GetComponent<Tile>().getY() - g2.GetComponent<Character>().isAt().GetComponent<Tile>().getY())) <= 1;

        Debug.Log(Math.Abs((int)(g1.GetComponent<Character>().isAt().GetComponent<Tile>().getX() - g2.GetComponent<Character>().isAt().GetComponent<Tile>().getX())) <= 1);
        Debug.Log(Math.Abs((int)(g1.GetComponent<Character>().isAt().GetComponent<Tile>().getY() - g2.GetComponent<Character>().isAt().GetComponent<Tile>().getY())) <= 1);
        return x && y;
    }

    public void nextTurn()
    {
        turnCounter++;
        if (activePlayer == player)
        {
            activePlayer.GetComponent<Character>().setDefaults();
            activePlayer = enemy;
        }
        else
        {
            activePlayer.GetComponent<Character>().setDefaults();
            activePlayer = player;
        }
            
    }

    public void handleAttack()
    {
        Debug.Log("Ima Chargin ma Laz0r");
        if(activePlayer == player)
        {
            activePlayer.GetComponent<Character>().attack(activePlayer, enemy);
        } else
        {
            activePlayer.GetComponent<Character>().attack(activePlayer, player);
        }
    }

    public static GameObject getActivePlayer()
    {
        return activePlayer;
    }

    public static void clearTiles(GameObject[][] all, GameObject chara, int x, int y)
    {
        for (int i = 0; i < all.Length; i++)
        {
            for (int j = 0; j < all.Length; j++)
            {
                //Debug.Log(all[i][j].GetComponent<Tile>().x + "," + all[i][j].GetComponent<Tile>().y);
                if (all[i][j].GetComponent<Tile>().getChar() == chara && (x != i || y != j))
                {

                    all[i][j].GetComponent<Tile>().setCharacter(null);
                }

                all[i][j].GetComponent<Tile>().setActive(null);
                all[i][j].GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
    public static void showMovement(GameObject[][] all, int x, int y, Color change, GameObject character)
    {
        all[x][y].GetComponent<Renderer>().material.color = change;
        for (int i = 0; i <= character.GetComponent<Character>().movement; i++)
        {
            for (int j = 0; j <= character.GetComponent<Character>().movement; j++)
            {
                if (i + j <= character.GetComponent<Character>().movement)
                {
                    if (x + i < all.Length)
                    {
                        if (y + j < all.Length)
                        {
                            if (all[x + i][y + j].GetComponent<Tile>().getChar() == null)
                            {
                                all[x + i][y + j].GetComponent<Renderer>().material.color = change;
                                all[x + i][y + j].GetComponent<Tile>().setActive(character);
                            }
                        }
                        if (y - j >= 0)
                        {
                            if (all[x + i][y - j].GetComponent<Tile>().getChar() == null)
                            {
                                all[x + i][y - j].GetComponent<Renderer>().material.color = change;
                                all[x + i][y - j].GetComponent<Tile>().setActive(character);
                            }
                        }
                    }
                    if (x - i >= 0)
                    {
                        if (y + j < all.Length)
                        {
                            if (all[x - i][y + j].GetComponent<Tile>().getChar() == null)
                            {
                                all[x - i][y + j].GetComponent<Renderer>().material.color = change;
                                all[x - i][y + j].GetComponent<Tile>().setActive(character);
                            }
                        }
                        if (y - j >= 0)
                        {
                            if (all[x - i][y - j].GetComponent<Tile>().getChar() == null)
                            {
                                all[x - i][y - j].GetComponent<Renderer>().material.color = change;
                                all[x - i][y - j].GetComponent<Tile>().setActive(character);
                            }
                        }
                    }
                }
            }
        }
    }
    public static GameObject findClosestPlayableCharacter(GameObject Enemy)
    {
        int maxDist = int.MaxValue;
        GameObject closest = null;
        foreach (GameObject Friendly in GameObject.FindGameObjectsWithTag("Friendly"))
        {
            int thisdistance = (Enemy.GetComponent<Character>().isAt().GetComponent<Tile>().getX() -
                Friendly.GetComponent<Character>().isAt().GetComponent<Tile>().getX()) +
            (Enemy.GetComponent<Character>().isAt().GetComponent<Tile>().getY() -
                Friendly.GetComponent<Character>().isAt().GetComponent<Tile>().getY());


            if (thisdistance < maxDist)
            {
                maxDist = thisdistance;
                closest = Friendly;
            }
        }
        return closest;
    }
}
