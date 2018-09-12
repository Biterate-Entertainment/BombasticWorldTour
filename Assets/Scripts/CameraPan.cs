using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public float speed = 10f;
    public GameObject camref;

    void LateUpdate()
    {
        if (Input.GetKey(("w")))
        {
            transform.position += camref.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            transform.position -= camref.transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= camref.transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            transform.position += camref.transform.right * speed * Time.deltaTime;
        }
    }
}