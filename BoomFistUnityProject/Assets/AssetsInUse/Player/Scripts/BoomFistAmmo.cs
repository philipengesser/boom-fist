using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomFistAmmo : MonoBehaviour
{
    public List<HudAmmo> HudAmmo;

    private int ammo;
    public int Ammo
    {
        get { return ammo; }
        set
        {
            ammo = value;

            if (ammo > MaxAmmo)
            {
                ammo = MaxAmmo;
            }

            for (int i = 0; i < MaxAmmo; i++)
            {
                if (ammo > i)
                {
                    HudAmmo[i].AmmoImage.color = Color.yellow;
                }
                else
                {
                    HudAmmo[i].AmmoImage.color = Color.black;
                }
            }
        }
    }

    private int maxAmmo;
    public int MaxAmmo
    {
        get { return maxAmmo; }
        set
        {
            maxAmmo = value;
            for (int i = 0; i < HudAmmo.Count; i++)
            {
                if (i < MaxAmmo)
                {
                    HudAmmo[i].gameObject.SetActive(true);
                }
                else
                {
                    HudAmmo[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public float AmmoRefreshTime;
    private float timeToNextAmmo;

    private void Start()
    {
        MaxAmmo = 3;
        Ammo = MaxAmmo;
        timeToNextAmmo = AmmoRefreshTime;
    }

    

    private void Update()
    {
        if (Ammo < MaxAmmo)
        {
            timeToNextAmmo -= Time.deltaTime;

            if (timeToNextAmmo <= 0)
            {
                timeToNextAmmo = AmmoRefreshTime;
                Ammo += 1;
            }
        }
    }
}
