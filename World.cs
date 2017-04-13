using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public static int turnCounter = 1;
    private static GameObject activePlayer = null;
    private static GameObject player = null;
    private static GameObject enemy = null;

    void Awake()
    {
        player = GameObject.Find("Cha_Knight");
        enemy = GameObject.Find("Knight");
        activePlayer = GameObject.Find("Cha_Knight");
    }

    void Update()
    {
        Debug.Log(activePlayer);
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
            activePlayer = player;
        }
            
    }

    public void handleAttack()
    {

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
}
