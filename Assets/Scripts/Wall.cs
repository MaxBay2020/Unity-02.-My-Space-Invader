using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //AudioSource shootingWallAudio;

    // Start is called before the first frame update
    void Start()
    {
        //shootingWallAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 播放子弹打到墙体的声音；
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Bullet" || collision.collider.gameObject.tag == "AlienBullet")
        {
            SoundManager.instance.PlayExplosionAtWall();
        }
    }
}
