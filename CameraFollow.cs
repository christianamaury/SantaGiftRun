using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Where the camera needs to follow.. 
    public Transform lookAt;

    //Old Vector position..
    private Vector3 offSet = new Vector3(0, 12.8f, -8.6f);
    private float speed = 7.3f;

    // Start is called before the first frame update
    void Start()
    {
        //Looking player.. 
        transform.position = lookAt.position + offSet;
    }

    private void LateUpdate()
    {
        cameraMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void cameraMovement()
    {
        //Where we would like the camera to be placed..
        Vector3 desiredPosition = lookAt.position + offSet;

        //Lerping through it..
        transform.position = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
    }
}
