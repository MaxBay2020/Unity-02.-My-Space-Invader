using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : Alien
{
    public float BoundLeft, BoundRight;

    public float speed;

    int direction = 1; //1代表右移，-1代表左移

    private void Awake()
    {
        if (Random.value > 0.5f) //随机数大于0.5时，UFO右移；
        {
            direction = 1;
        }
        else
        {
            direction = -1;//随机数小于0.5时，UFO左移；
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (direction == 1)
        {
            transform.position = new Vector2(BoundLeft, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(BoundRight, transform.position.y);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime * direction;

        if (direction == 1 && transform.position.x > BoundRight)
        {
            Destroy(gameObject);
        }

        if (direction == -1 && transform.position.x < BoundLeft)
        {
            Destroy(gameObject);
        }
    }
}
