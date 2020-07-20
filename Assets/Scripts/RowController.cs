using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowController : MonoBehaviour
{
    public float span = 0.04f;

    public float dropSpeed = 0.1f;

    public float direction, oldDirection;

    public GameObject gameOverImg;

  
    // Start is called before the first frame update
    void Start()
    {
        oldDirection = AliensManager.instance.direction;

        StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Move()
    {
        while (transform.position.y > -3.94f)
        {
            if(transform.childCount <= 0)
            {
                StopCoroutine("Move");

            }

            direction = AliensManager.instance.direction;

            transform.Translate(Vector3.right * AliensManager.instance.pace * Time.deltaTime * direction);

            //如果旧的方向不等于新方向，则表示方向改变，则让外星人向下移动；
            if (oldDirection != direction)
            {
                oldDirection = direction;

                transform.Translate(Vector3.down * dropSpeed);
            }

            yield return new WaitForSeconds(span);
        
        }

        //当transform.position.y < -3.94f时，游戏结束，显示Game Over；
        if (transform.position.y < -3.94f)
        {
            Debug.Log("Game Over!");

            gameOverImg.SetActive(true);
        }
    }
}
