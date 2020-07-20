using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource audioMaterial;

    public AudioClip clipShoot, clipExplosionAtWall, clipExplosionAtAlien, clipUFO;


    private void Awake()
    {
        instance = this;

        audioMaterial = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 发射子弹的声音
    /// </summary>
    public void PlayShootAudio()
    {
        audioMaterial.PlayOneShot(clipShoot);
    }

    /// <summary>
    /// 子弹打到墙体的声音
    /// </summary>
    public void PlayExplosionAtWall()
    {
        audioMaterial.PlayOneShot(clipExplosionAtWall);
    }
    
    /// <summary>
    /// 子弹打到外星人或玩家的声音
    /// </summary>
    public void PlayExplosionAtAlien()
    {
        audioMaterial.PlayOneShot(clipExplosionAtAlien);
    }

    /// <summary>
    /// UFO出现的声音
    /// </summary>
    public void PlayUFOAppearnce()
    {
        audioMaterial.PlayOneShot(clipUFO,1f);
    }

}
