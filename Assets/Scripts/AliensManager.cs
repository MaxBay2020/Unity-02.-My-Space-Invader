using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliensManager : MonoBehaviour
{
    public static AliensManager instance;

    public float direction = 1f; //1代表右移，-1代表左移；

    public float pace = 2f;

    public float acclerator = 0.08f;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
