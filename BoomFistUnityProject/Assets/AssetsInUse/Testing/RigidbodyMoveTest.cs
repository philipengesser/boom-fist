using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMoveTest : MonoBehaviour
{
    public Rigidbody rigidbody;

    public Vector3 positionForRigidbodyToMoveTowards;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.MovePosition(rigidbody.position + positionForRigidbodyToMoveTowards * Time.deltaTime);
    }
}
