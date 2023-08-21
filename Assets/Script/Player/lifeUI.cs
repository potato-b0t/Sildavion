using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable IDE1006
public class lifeUI : MonoBehaviour
{
    public Image HealthBar;

    private Player player;
#pragma warning disable IDE0090
    public Color green = new Color(0.6f, 1, 0.6f, 1);

#pragma warning disable IDE0051
    private void Start()
    {
        player = GetComponent<Controller>().player;
    }
    private void Update()
    {
        HealthBar.fillAmount = (float)player.life.getLife() / (float)player.life.max_life;


        if (player.life.getLife() * 100 / player.life.max_life >= 33f)
        {
            HealthBar.color = green;
        }
        else
        {
            Debug.Log("yes");
            HealthBar.color = Color.red;
        }
    }
}
