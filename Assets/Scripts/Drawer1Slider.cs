using UnityEngine;
using System.Collections;

public class Drawer1Slider : Slider {

    public Drawer drawerToOpen;

    // Use this for initialization
    public new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public new void Update () {
        base.Update();
        if (Position == 1 && Enabled) //hack 
        {
            this.Enabled = false;


            drawerToOpen.Open();


        }

    }
}
