using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0;

    internal Rigidbody2D rb;

    public GameObject explosionAtWall;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    public virtual void Start()
    {

        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    public virtual void Update()
    {
        rb.velocity = Vector2.up * Time.deltaTime * speed;
    }

    /// <summary>
    /// 子弹碰到空气墙，销毁子弹，并播放音效；
    /// </summary>
    /// <param name="collision"></param>
    public virtual void OnCollisionEnter2D(Collision2D collision)
    {

        //销毁子弹；
        Destroy(this.gameObject);

        if (collision.collider.gameObject.tag == "Wall")
        {
            //print(1);

            //播放爆炸动画；
            Animation anim = Instantiate(explosionAtWall, collision.contacts[0].point, Quaternion.identity).GetComponent<Animation>();

            anim.Play();

            Destroy(anim.gameObject, 0.5f);
        }

        //玩家子弹打中堡垒，销毁子弹和毁坏堡垒；
        if (collision.collider.gameObject.tag == "Fort")
        {
            Destroy(gameObject);

            Destroy(collision.collider.gameObject);
        }
    }
}
