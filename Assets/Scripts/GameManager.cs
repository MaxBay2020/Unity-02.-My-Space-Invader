using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Alien> aliens = new List<Alien>();

    public int aliensMaxCount, aliensCountOld;

    public Text scoreText;

    public float minForce = 2, maxForce = 4;

    public GameObject gameOverImg;

    public GameObject UFOPrefab;

    public Transform UFPTrans;

    public bool isWinning = false;

    public bool isDefeated = false;

    public GameObject winningImg;


    public AudioSource audioMaterials;

    public AudioClip clipDefeat, clipWin;

    public GameObject bgSound;

    public int aliensCount
    {
        get { return aliens.Count; }
    }

    private void Awake()
    {
        instance = this;
    }

    public int currentScore = 0;

    public int scoreAdd = 0;

    private GameObject[] go;

    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.FindGameObjectsWithTag("Alien");

        foreach (GameObject item in go)
        {
            aliens.Add(item.GetComponent<Alien>());
        }

        aliensCountOld = aliensMaxCount = aliens.Count;

        StartCoroutine("UpdateScore");

        //外星人发射子弹；
        InvokeRepeating("LaunchBullets", 1f, 3f);

        audioMaterials = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        print(aliens.Count);

        //游戏失败；
        if (isDefeated)
        {
            gameOverImg.SetActive(true);

            isDefeated = true;

            //停止背景音乐；
            bgSound.GetComponent<AudioSource>().Stop();

            //播放失败的音频；
            if (!audioMaterials.isPlaying)
            {
                audioMaterials.PlayOneShot(clipDefeat);
            }

            //按任意键，返回菜单界面；
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        //游戏胜利；
        if (aliens.Count == 0)
        {
            winningImg.SetActive(true);

            isWinning = true;

            //停止背景音乐；
            bgSound.GetComponent<AudioSource>().Stop();

            //播放失败的音频；
            if (!audioMaterials.isPlaying)
            {
                audioMaterials.PlayOneShot(clipWin);
            }

            //按任意键，返回菜单界面；
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void Flash()
    {
        StartCoroutine("FlashAliens");
    }

    IEnumerator FlashAliens()
    {
        for (int i = 0; i < 6; i++)
        {
            foreach (Alien a in aliens)
            {
                if (i != 5)
                {
                    //外星人闪烁；
                    a.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, i % 2);
                }
                else
                {
                    //外星人闪烁；
                    a.GetComponent<SpriteRenderer>().color = Color.white;
                }

            }

            yield return new WaitForSeconds(0.2f);

        }

        isDefeated = true;

        StopCoroutine(FlashAliens());
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            if (scoreAdd / 10 > 0)
            {
                scoreAdd -= 10;

                currentScore += 10;

                scoreText.text = currentScore.ToString("00000");

                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(0.3f);
            }

        }

    }

    void LaunchBullets()
    {
        //游戏失败，结束此方法；
        if (isDefeated || isWinning)
        {
            return;
        }

        int bullets = Random.Range(1, 5);

        if (bullets > aliensCount && aliensCount != 0)
        {
            bullets = aliensCount;
        }

        for (int i = 0; i < bullets; i++)
        {
            int index = Random.Range(0, aliensCount);

            EnemyBullet eb = Instantiate(aliens[index].bullet, aliens[index].transform.position, Quaternion.identity).GetComponent<EnemyBullet>();

            eb.AddForce(Random.Range(minForce, maxForce));
        }
    }

    /// <summary>
    /// 当消灭5个外星人，创建UFO；
    /// </summary>
    public void SpawnUFO()
    {
        if (aliensCount % 5 == 0 && aliensCountOld != aliensCount)
        {
            aliensCountOld = aliensCount;

            Instantiate(UFOPrefab, UFPTrans.position, Quaternion.identity);

            SoundManager.instance.PlayUFOAppearnce();
        }
    }


}
