using UnityEngine;
using System.Collections;

public class Drawer1Button : Button {

    public Drawer drawerToOpen;

    // Use this for initialization
    public new void  Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public new void Update () {
        base.Update();
        if (pushedDown && Enabled) //hack 
        {
            this.Enabled = false;
           
            
            drawerToOpen.Open();


        }
    }
}
