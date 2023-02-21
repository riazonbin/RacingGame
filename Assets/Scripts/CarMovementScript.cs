using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarMovementScript : MonoBehaviour
{
    public float carSpeed = 5f;
    public Transform leftBorder;
    public Transform rightBorder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        var target = transform.position;
        target.x += horizontalInput;
        transform.position = Vector3.MoveTowards(transform.position, target, carSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform == leftBorder || collision.transform == rightBorder)
        {
            SceneManager.LoadScene(0);
        }
    }
}
