using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovementScript : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= -4.56f)
        {
            transform.position = new Vector3(transform.position.x, -0.76f, transform.position.z);
        }
    }
}
