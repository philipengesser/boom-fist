using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoomFistHP : MonoBehaviour
{
    public List<PlayerHeart> Hearts;

    private int hp;
    public int HP {
        get { return hp; }
        set
        {
            hp = value;

            if (hp > MaxHP)
            {
                hp = MaxHP;
            }

            for (int i = 0; i < MaxHP; i++)
            {
                if (hp > i)
                {
                    Hearts[i].HeartImage.color = Color.red;
                }
                else
                {
                    Hearts[i].HeartImage.color = Color.black;
                }
            }

            if (hp <= 0)
            {
                //Lose game
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private int maxHP;
    public int MaxHP {
        get { return maxHP; }
        set
        {
            maxHP = value;
            for (int i = 0; i < Hearts.Count; i++)
            {
                if (i < MaxHP)
                {
                    Hearts[i].gameObject.SetActive(true);
                }
                else
                {
                    Hearts[i].gameObject.SetActive(false);
                }
            }
        }
    }

    private void Start()
    {
        MaxHP = 3;
        HP = MaxHP;
    }
}
