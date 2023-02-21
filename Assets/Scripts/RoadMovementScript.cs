using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovementScript : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= -8.56f)
        {
            transform.position = startPosition;
        }
    }
}
