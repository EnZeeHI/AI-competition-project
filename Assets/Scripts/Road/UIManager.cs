/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text TextBox1;
    public Text TextBox2;
    public GameObject Tank1;
    public GameObject Tank2;
    public TankControllerUniversal Tank1Health;
    public TankControllerUniversal Tank2Health;
    public Slider HealthSlider1;
    public Slider HealthSlider2;

    // Start is called before the first frame update
    void Start()
    {   
        Tank1 = GameObject.Find("Tank1");
        Tank2 = GameObject.Find("Tank2");

        TextBox1 = Tank1.GetComponent<Text>();
        TextBox2 = Tank2.GetComponent<Text>();
        
        Tank1Health = Tank1.GetComponentInChildren<TankControllerUniversal>();
        Tank2Health = Tank2.GetComponentInChildren<TankControllerUniversal>();

    }

    //Update is called once per frame

    //doesnt work right now
    void Update()
    {
        TextBox1.text = "Tank 1 Health" + Tank1Health.CurrentHealth;
        TextBox2.text = "Tank 2 Health" + Tank2Health.CurrentHealth;
        HealthSlider1.value = Tank1Health.CurrentHealth;
        HealthSlider2.value = Tank2Health.CurrentHealth;
    }
}
*/