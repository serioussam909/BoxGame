using UnityEngine;
using System.Collections;

public class Drawer : PuzzleObject {

    public bool opening;
    public bool opened;
    public Vector3 openedOffset;
    public float openSpeed = 1;
    Vector3 initPos;
    Vector3 targetPos;
    public AudioClip openingSound;

    public void Open()
    {
        
        if (!opening)
        {
            AudioSource.PlayClipAtPoint(openingSound, transform.position);
        }
        opening = true;
    }

	// Use this for initialization
	public new void Start () {
        base.Start();
        initPos = transform.localPosition;
        targetPos = initPos + openedOffset;
    }

    // Update is called once per frame
    public new void Update () {
        base.Update();
        if (opening)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, openSpeed * Time.deltaTime);   
        }
        if (transform.localPosition.Equals(targetPos))
        {
            opened = true;
            opening = false;
            linkedCamTarget.Enabled = true;
        }
    }
}
