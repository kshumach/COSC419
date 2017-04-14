using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HPScript : MonoBehaviour {

    public int type;
    public float total;
    public float current;
    Text hp;

	// Use this for initialization
	void Start () {
        hp = GetComponent<Text>();
		if(type == 0)
        {
            total = GameObject.Find("Cha_Knight").GetComponent<Character>().totalHp;
            current = GameObject.Find("Cha_Knight").GetComponent<Character>().totalHp;
            updateDisplay();
        } else
        {
            total = GameObject.Find("knight").GetComponent<Character>().totalHp;
            current = GameObject.Find("knight").GetComponent<Character>().totalHp;
            updateDisplay();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (type == 0)
        {
            current = GameObject.Find("Cha_Knight").GetComponent<Character>().health;
            updateDisplay();
        }
        else
        {
            current = GameObject.Find("knight").GetComponent<Character>().health;
            updateDisplay();
        }
    }

    void updateDisplay()
    {
        hp.text = current + "/" + total;
    }
}
