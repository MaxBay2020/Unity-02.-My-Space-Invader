using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public static PlayerController instance;

    public GameObject bulletPrefab;

    public Transform launchPoint;

    public float shootingTime = 0.5f;

    private void Awake()
    {
        instance = this;

        //launchPoint = transform.Find("launchPoint");

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //游戏结束，不能控制玩家；
        if (GameManager.instance.isWinning || GameManager.instance.isDefeated)
        {
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");

        //print(h);
        //if (h != 0)
        //{
        Vector2 pos = transform.position;

        pos.x += h * Time.fixedDeltaTime * speed;

        pos.x = Mathf.Clamp(pos.x, -6f, 6f);

        transform.position = pos;
        //}

        //按下空格，发射子弹；每隔0.5s发射一次子弹；播放发射子弹音效；
        if (Input.GetKeyDown(KeyCode.Space) && shootingTime >= 0.5f)
        {
            //Vector3 position = launchPoint.position;

            GameObject bullet = Instantiate(bulletPrefab, launchPoint.position, Quaternion.identity);

            SoundManager.instance.PlayShootAudio();

            shootingTime = 0f;
        }
        else
        {
            shootingTime += Time.fixedDeltaTime;

            //print(shootingTime);
        }
    }
}
