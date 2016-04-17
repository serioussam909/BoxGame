using UnityEngine;
using System.Collections;

public class CameraPivot : MonoBehaviour {

    public bool Override = true;
    public float distance = 1.3f;
    public float yMinLimit = -80f;
    public float yMaxLimit = 80f;

    public float xMinLimit = -180f;
    public float xMaxLimit = 180f;

    public bool Enabled = true;

    GameObject camObj;
    public MainCamera cam;
    Collider coll;

    // Use this for initialization
    void Start () {
        camObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = camObj.GetComponent<MainCamera>();
        coll = GetComponent<Collider>();
    }

    public bool isTargeted()
    {
        return cam.target == this;
    }
	
	// Update is called once per frame
	void Update () {
        if (isTargeted())
        {
            if (coll != null)
            {
                coll.enabled = false;
            }
        }
	    if(!isTargeted()&&cam.canZoomToTargets())
        {
            if (coll != null)
            {
                coll.enabled = true;
            }
        }
	}
    
    public void OnMouseDown()
    {
        if(!isTargeted() && Enabled && cam.canZoomToTargets())
        {
            cam.SetTarget(this);
        }
    }

}
