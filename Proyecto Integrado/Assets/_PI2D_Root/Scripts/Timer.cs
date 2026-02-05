using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public float timer = 0;
    public Text timerText;


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = ""+timer.ToString("f0");
    }

}
