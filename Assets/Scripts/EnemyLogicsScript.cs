using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogicsScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(-4f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == "TopBorder" || collision.transform.name == "BottomBorder")
        {
            Destroy(gameObject);
            return;
        }
        if(collision.gameObject.name == "Car")
        {
            Time.timeScale = 0.0f;
            return;
        }

        Destroy(collision.gameObject);
        Destroy(gameObject);

    }
}
