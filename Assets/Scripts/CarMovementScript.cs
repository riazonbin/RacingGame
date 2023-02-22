using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            Time.timeScale = 0.0f;

            var loseCanvas = SceneManager.GetActiveScene().
                GetRootGameObjects().FirstOrDefault(x => x.name == "EndGameCanvas");
            loseCanvas.gameObject.SetActive(true);
        }
    }
}
