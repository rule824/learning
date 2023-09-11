using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Image HealthBar;
    public static UImanager instance { get; private set;}
    public void UpdateHealthBar(int currentHealth, int amount) {
        HealthBar.fillAmount = (float)currentHealth / (float)amount;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
