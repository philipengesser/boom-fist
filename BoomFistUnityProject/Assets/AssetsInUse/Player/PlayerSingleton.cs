using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static PlayerSingleton S;

    [HideInInspector] public Transform PlayerTransform;

    public static Vector3 PlayerPosition{
        get { return S.PlayerTransform.position; }
        set { S.PlayerTransform.position = value; }
    }

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
