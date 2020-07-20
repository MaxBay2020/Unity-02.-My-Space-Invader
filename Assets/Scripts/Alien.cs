using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject bullet;

    SpriteRenderer sr;

    Sprite sprite0;

    public Sprite sprite1;

    public float tm0 = 0.2f, tm1 = 0.4f;

    private float currentTime = 0;

    public GameObject explosionAtAlien;

    public GameObject score30Animation;

    public int score = 30;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        sprite0 = sr.sprite;

    }
    // Start is called before the first frame update
    void Start()
    {
        currentTime += Random.Range(0, 1);

    }

    // Update is called once per frame
    void Update()
    {
        ExchangeSprite();
    }

    /// <summary>
    /// 贴图轮换更替
    /// </summary>
    void ExchangeSprite()
    {
        currentTime += Time.deltaTime;

        if (currentTime > tm0)
        {
            sr.sprite = sprite1;
        }

        if (currentTime > tm1)
        {
            sr.sprite = sprite0;
        }

        if (currentTime > tm0 + tm1)
        {
            currentTime = 0;
        }
    }

    /// <summary>
    /// 外星人或玩家被子弹打中，销毁、爆炸特效、音效；
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //游戏失败，结束此方法；
        if (GameManager.instance.isDefeated)
        {
            return;
        }

        if (collision.collider.gameObject.tag == "Bullet" || collision.collider.gameObject.tag == "Player")
        {
            SoundManager.instance.PlayExplosionAtAlien();


            GameObject explosionAtAlienGo = Instantiate(explosionAtAlien, transform.position, transform.rotation);

            Destroy(explosionAtAlienGo, 0.5f);

            GameObject score30 = Instantiate(score30Animation, transform.position, transform.rotation);

            Destroy(score30, 1f);


            //消灭外星人，外星人移动速度加快；
            AliensManager.instance.pace += AliensManager.instance.acclerator;

            GameManager.instance.aliens.Remove(this);

            Destroy(gameObject);

            GameManager.instance.scoreAdd += score;

            //消灭外星人，创建UFO；
            GameManager.instance.SpawnUFO();

        }

        //碰到左侧墙壁，向右移动；
        if (collision.collider.gameObject.tag == "LeftWall")
        {
            AliensManager.instance.direction = 1;
        }

        //碰到左侧墙壁，向右移动；
        if (collision.collider.gameObject.tag == "RightWall")
        {
            AliensManager.instance.direction = -1;
        }
    }
}
