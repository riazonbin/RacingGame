using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLogicsScript : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.name.Contains("TopSpawn"))
        {
            speed = Random.Range(-5f, -2f);
            return;
        }
        speed = Random.Range(2f, 5f);
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
            var loseCanvas = SceneManager.GetActiveScene().
                GetRootGameObjects().FirstOrDefault(x => x.name == "EndGameCanvas");
            loseCanvas.gameObject.SetActive(true);
            return;
        }

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
