using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class MainCamera: MonoBehaviour
{

    public CameraPivot target;
    public CameraPivot defaultTarget;
    float distance = 2.0f;
    float xSpeed = 120.0f;
    float ySpeed = 120.0f;

    float yMinLimit = -80f;
    float yMaxLimit = 80f;

    float xMinLimit = -80f;
    float xMaxLimit = 80f;

    public float defDistance = 2.0f;

    public float defYMinLimit = -80f;
    public float defYMaxLimit = 80f;


    public float defXMinLimit = -80f;
    public float defXMaxLimit = 80f;

    private Rigidbody rigidbody;

    float x = 0.0f;
    float y = 0.0f;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    public void SetTarget(CameraPivot camTarget)
    {
        this.target = camTarget;
    }

    public void ResetTarget()
    {
        this.target = defaultTarget;
    }

    public bool canZoomToTargets()
    {
        return target == defaultTarget;
    }

    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetButtonDown("Cancel")||Input.GetMouseButtonDown(2))
            {
                SetTarget(defaultTarget);
                return;
            }
            if (target.Override)
            {
                distance = target.distance;
               

                yMinLimit = target.yMinLimit;
                yMaxLimit = target.yMaxLimit;

                xMinLimit = target.xMinLimit; 
                xMaxLimit = target.xMaxLimit;
            }
            else
            {
                distance = defDistance;

                 yMinLimit = defYMinLimit;
                 yMaxLimit = defYMaxLimit;

                 xMinLimit = defXMinLimit;
                 xMaxLimit = defXMaxLimit;

            }
            if (Input.GetMouseButton(1))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            }
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            //   distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
         //   distance = Mathf.Clamp(distance, distanceMin, distanceMax);
         /*   RaycastHit hit;
            if (Physics.Linecast(target.transform.position, transform.position, out hit))
            {
             //   distance -= hit.distance;
            } */
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.transform.position;

            transform.rotation = rotation;
            transform.position = position;
        }
        if (whiteOut) {
            if (GetComponent<ScreenOverlay>().intensity < 2)
            {
                GetComponent<ScreenOverlay>().intensity += .5f * Time.deltaTime;
            }
                }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
    //hack
    bool whiteOut = false;
    public void WhiteOut()
    {
        whiteOut = true;
    }
}