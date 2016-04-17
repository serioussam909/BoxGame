using UnityEngine;
using System.Collections;

public class Button : PuzzleObject {


    public bool Toggle = true;
    public bool pushed = false;
    public bool activated = false;
    public bool pushedDown = false;

    public Vector3 pushedOffset = new Vector3(0f, 1f, 0.0f);
    Vector3 initPos;
    Vector3 targetPos;
    public float pushSpeed = .3f;
    public AudioClip clickSound;

   

	// Use this for initialization
	public new  void Start () {
        base.Start();
        initPos = transform.localPosition;
        targetPos = initPos + pushedOffset;
	}
	
	// Update is called once per frame
	public new void Update () {
	    if(pushed)
        {

            transform.localPosition = Vector3.MoveTowards (transform.localPosition, targetPos, pushSpeed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, initPos, pushSpeed * Time.deltaTime);
        }
        if(transform.localPosition.Equals(targetPos))
        {
            pushedDown = true;
        }
        else
        {
            pushedDown = false;
        }
	}

    public void OnMouseDown()
    {
     //   AudioSource.PlayClipAtPoint(clickSound, transform.position);
        
        if (isInteractive())
        {
            if(!Toggle)
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
