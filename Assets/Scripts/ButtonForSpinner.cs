using UnityEngine;
using System.Collections;

public class ButtonForSpinner : Button {

    public Spinner spinner;
    public int direction = 0;
    public bool released = true;

	// Use this for initialization
	public new void Start () {
        base.Start();
	}

    // Update is called once per frame
    public new void Update () {
        base.Update();
        if (pushedDown && Enabled && released) //hack 
        {
            released = false;
            spinner.Turn(direction);

        }
        if (pushedDown == false)
        {
            released = true;
        }
    }
}
