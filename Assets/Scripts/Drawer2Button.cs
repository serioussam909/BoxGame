using UnityEngine;
using System.Collections;

public class Drawer2Button : Button {

    public Drawer drawerToOpen;
    public Drawer drawerToOpen2;
    public Clock clockToCheck;
    // Use this for initialization
    public new void Start () {
        base.Start();
	}

    public bool checkClock()
    {
        int hour = clockToCheck.Hour;
        int minute = clockToCheck.Minute;
        int nowHour = System.DateTime.Now.Hour;

        if (nowHour > 12)
        {
            nowHour -= 12;
        }
        
        int nowMinute = System.DateTime.Now.Minute;
        return ((hour == nowHour) && (minute == nowMinute));
        
    }

    // Update is called once per frame
    public new void Update () {
        base.Update();
        if (pushedDown && Enabled&&checkClock()) //hack 
        {
            this.Enabled = false;
            this.linkedCamTarget.Enabled = false;
            this.cam.ResetTarget();
            drawerToOpen.Open();
            drawerToOpen2.Open();

        }
    }
}
