using UnityEngine;
using System.Collections;

public class InitButton : Button {

    public Drawer drawerToOpen;

    // Use this for initialization
    new void Start () {
        base.Start();
	}

    // Update is called once per frame
    public  new void Update()
    {
        base.Update();
        if (pushedDown&&Enabled) //hack 
        {
            this.Enabled = false;
            this.linkedCamTarget.Enabled = false;
            this.cam.ResetTarget();
            drawerToOpen.Open();
          
           
        }
    }
}
