using UnityEngine;
using System.Collections;

public class SwitchObject : PuzzleObject {


    public bool Toggle = true;
    public bool pushed = false;
    public bool activated = false;
    public bool pushedDown = false;

    public float pushedOffset = 0;
    float initRot;
    float targetRot;
    public float pushTime = .5f;

    // Use this for initialization
    public new void Start () {
        base.Start();
        base.Start();
        initRot = transform.localEulerAngles.z;
        targetRot = initRot - pushedOffset;
        if (targetRot < 0)
        {
            targetRot = 360 - targetRot;
        }
    }
	
	// Update is called once per frame

    public new void Update()
    {
        base.Update();

        if (pushed)
        {
            transform.localEulerAngles = new Vector3(0,0,targetRot);
            
            
            
                pushedDown = true;
            
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, initRot);

                pushedDown = false;
            
        }
       
    }

    public void OnMouseDown()
    {
        if (isInteractive())
        {
            if (!Toggle)
            {
                pushed = true;
            }
        }
    }

    public void OnMouseUpAsButton()
    {
        if (isInteractive())
        {
            if (Toggle && pushed)
            {
                pushed = false;
                return;
            }
            if (Toggle && !pushed)
            {
                pushed = true;
                return;
            }
            if (!Toggle)
            {
                pushed = false;
            }

        }
    }
}
