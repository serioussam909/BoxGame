using UnityEngine;
using System.Collections;

public class ClockHand : PuzzleObject {



	// Use this for initialization
	public new void Start () {
	
	}

    // Update is called once per frame
    public new void Update () {
	    
	}
    private Vector3 screenPoint;
    private Vector3 offset;
    void OnMouseDown()
    {
        if (Interactive)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (Interactive)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;

            //another hack 
            // Vector3 cursorLocalPos = transform.InverseTransformPoint(cursorPosition);

            transform.LookAt(cursorPosition);
            transform.localEulerAngles=new Vector3(90,transform.localEulerAngles.y-90,0);
        }
    }
}
