using UnityEngine;
using System.Collections;

public class FinalButton : Button {

    public Drawer drawerToOpen;
    public Drawer drawerToOpen1;

    public Drawer drawerToOpen2;
    public Drawer drawerToOpen3;
    public Drawer drawerToOpen4;
    public Drawer drawerToOpen5;
    public Spinner spinnerToCheck1;

    public Spinner spinnerToCheck2;
    public Spinner spinnerToCheck3;
    public Spinner spinnerToCheck4;
    public AudioClip levelComplete;
    // Use this for initialization
    public new void Start () {
        base.Start();
	}

    public bool CheckSpinners()
    {
       // return true;
        if (
            spinnerToCheck1.currentSymbol == SpinnerSymbol.Pentagram &&
            spinnerToCheck2.currentSymbol == SpinnerSymbol.Circle &&
            spinnerToCheck3.currentSymbol == SpinnerSymbol.Square &&
            spinnerToCheck4.currentSymbol == SpinnerSymbol.Triangle 
            )
        {
            return true;
        }
        return false;
    }
	
	// Update is called once per frame
	public new void Update () {
        base.Update();
        if (pushedDown && Enabled) //hack 
        {
            if (CheckSpinners())
            {
                this.Enabled = false;
                this.linkedCamTarget.Enabled = false;
                this.cam.ResetTarget();
                drawerToOpen1.Open();
                drawerToOpen2.Open();
                drawerToOpen3.Open();
                drawerToOpen4.Open();
                drawerToOpen5.Open();
                drawerToOpen.Open();
                cam.WhiteOut();
                AudioSource.PlayClipAtPoint(levelComplete, Vector3.zero);
            }
            else
            {

            }
        }
    }
}
