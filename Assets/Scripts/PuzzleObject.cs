using UnityEngine;
using System.Collections;

public class PuzzleObject : MonoBehaviour {

    public CameraPivot linkedCamTarget; //prevent interaction unless camera is nearby
    GameObject camObj;
    public MainCamera cam;
    public bool Enabled = true;
    Collider coll;
    public bool Interactive = true;

    // Use this for initialization
    public void Start () {
        camObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = camObj.GetComponent<MainCamera>();
        coll = GetComponent<Collider>();
    }
	
	// Update is called once per frame
	public void Update () {
	
	}

    public bool isInteractive()
    {
        return Enabled && linkedCamTarget.isTargeted();
    }
}
