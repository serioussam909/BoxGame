using UnityEngine;
using System.Collections;

public class Slider : PuzzleObject {

    public float Position = 0;
    Vector3 minPos;
    Vector3 maxPos;
  
    public Vector3 sliderOffset;
    // Use this for initialization
    public new void Start () {
        base.Start();
        minPos = transform.localPosition;
        maxPos = minPos + sliderOffset;
    }
	
	// Update is called once per frame
	public new void Update () {
        base.Update();
        float maxLength = Vector3.Magnitude(minPos - maxPos);
        float curLength = Vector3.Magnitude(minPos - transform.localPosition);
        Position = curLength / maxLength;
    }

    void OnMouseDown()
    {
        if (isInteractive())
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (isInteractive())
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;

            //another hack 
            Vector3 cursorLocalPos = transform.InverseTransformPoint(cursorPosition);
            if(sliderOffset.x!=0)
            {
                float tempPos = Mathf.Clamp(cursorLocalPos.x, minPos.x, maxPos.x);
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(tempPos, transform.localPosition.y, transform.localPosition.z),10*Time.deltaTime);
            }
            if (sliderOffset.y != 0)
            {
                float tempPos = Mathf.Clamp(cursorLocalPos.y, minPos.y, maxPos.y);
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, tempPos, transform.localPosition.z), 10 * Time.deltaTime);
            }
            if (sliderOffset.z != 0)
            {
                float tempPos = Mathf.Clamp(cursorLocalPos.z, minPos.z, maxPos.z);
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, transform.localPosition.y,tempPos), 10 * Time.deltaTime);
            }
        }
    }

    private Vector3 screenPoint;
    private Vector3 offset;

}
