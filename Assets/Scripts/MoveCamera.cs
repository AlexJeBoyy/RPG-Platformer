using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 camOffSet;
    // Start is called before the first frame update
    void Start()
    {
        camOffSet = transform.position - targetObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + camOffSet;
        transform.position = newPosition;
    }
}
