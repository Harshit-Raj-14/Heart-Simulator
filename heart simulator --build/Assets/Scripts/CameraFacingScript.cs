using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingScript : MonoBehaviour
{
    void LateUpdate()   //its called after all update frames called
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * -Vector3.forward,
                                                Camera.main.transform.rotation * Vector3.up);
    }
}

/*This script has been written so that text in bubble shows in which ever direction camera faces and at all angles
*/

