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
    private Vector2 _direction;
    bool _isTurning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isTurning)
        {
            transform.position = Vector3.MoveTowards(transform.position, _direction, carSpeed * Time.deltaTime);
            if (transform.position.x == _direction.x)
            {
                _isTurning = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && !_isTurning)
        {
            _direction.x = transform.position.x - 2;
            _isTurning = true;
        }
        if (Input.GetKeyDown(KeyCode.D) && !_isTurning)
        {
            _direction.x = transform.position.x + 2;
            _isTurning = true;
        }
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
