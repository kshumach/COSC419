using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

    private bool Selected = false;

    public void toggleSelected()
    {
        this.Selected = !this.Selected;
    }
}
