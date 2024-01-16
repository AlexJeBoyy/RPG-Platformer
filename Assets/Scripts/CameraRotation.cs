using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;

using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraRotation : MonoBehaviour
{
    [Header("Camera Movement")]
    public Transform player;
    private float xMouse;
    private float yMouse;
    private float xRotation;
    private float yRotation;
    public float speed = 1000f;
    public Transform orientation;




    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

        xMouse = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        yMouse = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        yRotation += xMouse;
        xRotation -= yMouse;
        xRotation = Mathf.Clamp(xRotation, -90, 90);


        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        // player.Rotate(Vector3.up * xMouse);
    }
    private void OnGUI()
    {

    }
}
