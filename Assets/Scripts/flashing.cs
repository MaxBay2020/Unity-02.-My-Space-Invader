using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class flashing : MonoBehaviour
{
    public Text startInfo;

    private float r, g, b, a;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        r = startInfo.color.r;
        g = startInfo.color.g;
        b = startInfo.color.b;
        a = Mathf.PingPong(Time.time / 1f, 1);
        a = Mathf.Clamp(a, 0.1f, 1);
        startInfo.color = new Color(r, g, b, a);

        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
