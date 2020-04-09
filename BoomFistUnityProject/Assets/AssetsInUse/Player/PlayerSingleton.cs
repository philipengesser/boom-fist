using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static PlayerSingleton S;

    [HideInInspector] public Transform PlayerTransform;

    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }

        PlayerTransform = this.transform;

    }

    private void Start()
    {
        
    }
}
