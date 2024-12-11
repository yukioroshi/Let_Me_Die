using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camer : MonoBehaviour
{

    public Transform PlayerTransform;

    public Transform CameraTransform;

    // Update is called once per frame
    void Update()
    {
        CameraTransform.position = PlayerTransform.position;
    }
}
