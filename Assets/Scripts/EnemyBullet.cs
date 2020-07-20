using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : Bullet
{
    public GameObject gameOverImg;

    public GameObject explosionAtAlien;


    // Start is called before the first frame update
    public override void Start()
    {

    }

    public void AddForce(float force)
    {
        //rb.velocity = Vector2.down * Time.deltaTime * speed;

        rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Wall" || collision.collider.gameObject.tag == "Bullet")
        {
            //print(1);

            //播放爆炸动画；
            Animation anim = Instantiate(explosionAtWall, collision.contacts[0].point, Quaternion.identity).GetComponent<Animation>();

            anim.Play();

            //播放声音；
            SoundManager.instance.PlayExplosionAtWall();

            Destroy(anim.gameObject, 0.5f);
        }

        //销毁子弹；
        Destroy(this.gameObject);

        //敌人子弹打到玩家，销毁玩家；
        if (collision.collider.gameObject.tag == "Player")
        {
            //print(1);

            //播放爆炸动画；
            GameObject explosionAtAlienGo = Instantiate(explosionAtAlien, transform.position, transform.rotation);

            Destroy(explosionAtAlienGo, 0.5f);

            //播放音频；
            SoundManager.instance.PlayExplosionAtAlien();

            Destroy(collision.collider.gameObject);


            //子弹打到玩家，外星人闪烁，并游戏结束；
            GameManager.instance.Flash();


        }

        //外星人子弹打中堡垒，销毁子弹和毁坏堡垒；
        if (collision.collider.gameObject.tag == "Fort")
        {
            Destroy(gameObject);

            Destroy(collision.collider.gameObject);

            //播放爆炸动画；
            Animation anim = Instantiate(explosionAtWall, collision.contacts[0].point, Quaternion.identity).GetComponent<Animation>();

            anim.Play();

            Destroy(anim.gameObject, 0.5f);

            //播放音频；
            SoundManager.instance.PlayExplosionAtWall();
        }
    }

    //void GameOver()
    //{
    //    gameOverImg.SetActive(true);
    //}
}
