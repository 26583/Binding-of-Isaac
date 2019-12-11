using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private int health = 3;
    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite HeartFilled;
    [SerializeField]
    private Sprite HeartNotFilled;

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        if(health < 3)
        {
            hearts[2].sprite = HeartNotFilled;
        }
        if (health < 2)
        {
            hearts[1].sprite = HeartNotFilled;
        }
        if (health < 1)
        {
            hearts[0].sprite = HeartNotFilled;
        }
    }
    public void Damage()
    {
        health--;
    }
}
