// allows the user to look around in play mode. Uses standard WASD controlls and shift/space to
// raise and lower camera

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    [Range(0.0f,4.0f)] public float pitchSensitivity;
    [Range(0.0f,4.0f)] public float yawSensitivity;
    [Range(0.0f,0.5f)] public float moveSensitivity;

    private float yaw, pitch;
    // Update is called once per frame

    private void Start() {
        Cursor.visible = false;
    }

    private void Update()
    {
        // get changes to camera direction from mouse axis
        yaw += yawSensitivity * Input.GetAxis("Mouse X");
        pitch -= pitchSensitivity * Input.GetAxis("Mouse Y");
    
        
        Vector3 deltaPos=Vector3.zero;
        
        // get changes to camera position from key inputs
        if (Input.GetKey("w")){deltaPos+=transform.forward;}
        if (Input.GetKey("a")){deltaPos-=transform.right;}
        if (Input.GetKey("s")){deltaPos-=transform.forward;}
        if (Input.GetKey("d")){deltaPos+=transform.right;}

        if (Input.GetKey("space")){deltaPos+=Vector3.up;}
        if (Input.GetKey("right shift")||Input.GetKey("left shift")){deltaPos+=Vector3.down;}

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.position+=moveSensitivity* deltaPos;
    }
}
