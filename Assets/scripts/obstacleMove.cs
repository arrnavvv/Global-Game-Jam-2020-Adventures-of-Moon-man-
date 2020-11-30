using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMove : MonoBehaviour
{
    public float speed;
    public float xForDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "obstacle" || gameObject.tag=="spike"||gameObject.tag=="levelTrigger"||gameObject.tag=="lifePick")
        {
            moveLeft();
            if (transform.position.x < xForDestroy)
            {
                Destroy(gameObject);
            }
        }

        if (gameObject.tag == "enemyLeft")
        {
            moveLeft();
        }
        if (gameObject.tag == "enemyRight")
        {
            moveRight();
        }
        if (gameObject.tag == "enemyDown")
        {
            moveDown();
        }
    }

    public void moveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void moveDown()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public void moveRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
