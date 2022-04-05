using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTarget;
    public Transform lookTarget;
    public float sSpeed = 80.0f;
    public Vector3 dist;
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // transform.position = player.transform.position + distance;
        // transform.rotation = player.transform.rotation;
        Vector3 dPos = cameraTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }
}
