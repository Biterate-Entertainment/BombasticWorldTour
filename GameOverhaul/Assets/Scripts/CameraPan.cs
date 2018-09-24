using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public float speed = 0.25f;
    public GameObject camref;

    public bool interactive = true;

    public bool toMove = false;

    private void Start()
    {

    }
    void LateUpdate()
    {
        if (interactive == true)
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

    public IEnumerator RetargetCamera(Vector3 target, float time)
    {
        interactive = false;
        Vector3 startPosition = transform.position;
        float startTime = Time.time;
        while (Time.time < startTime + time)
        {
            transform.position = Vector3.Lerp(startPosition, target, (Time.time - startTime) / time);
            yield return null;
        }
        interactive = true;
        transform.position = target;
    }
}