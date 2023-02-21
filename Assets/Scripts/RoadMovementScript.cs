using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovementScript : MonoBehaviour
{
    public float scrollSpeed;
    public float repeatDistance;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position += new Vector3(0, -scrollSpeed * Time.deltaTime, 0);

        if (transform.position.y < startPosition.y + repeatDistance)
        {
            transform.position = startPosition;
        }
    }
}
