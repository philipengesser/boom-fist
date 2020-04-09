using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoomFistPunch : MonoBehaviour
{
    

    public float Range;
    public float ExplosionForce;

    private vThirdPersonController characterController;
    private Transform myTransform;
    private Rigidbody myRigidbody;

    private Vector3 midPoint
    {
        get
        {
            return new Vector3(myTransform.position.x, myTransform.position.y + 1, myTransform.position.z);
        }
    }

    //private Transform offSetTransform
    //{
    //    get
    //    {
    //        Transform newTransform = new Transform();
    //        return myTransform.position
    //    }
    //}

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        characterController = this.GetComponent<vThirdPersonController>();
        myTransform = this.transform;
        myRigidbody = this.GetComponent<Rigidbody>();
    }

    public void Punch(Vector3 punchTarget)
    {

        
        RaycastHit hit;
        if (Physics.SphereCast(midPoint, .2f, punchTarget, out hit, Range))
        {
            //characterController._capsuleCollider.material = characterController.slippyPhysics;
            Vector3 trajectory = (midPoint - hit.point).normalized;
            myRigidbody.AddForce(trajectory * ExplosionForce, ForceMode.VelocityChange);
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Punch((-myTransform.forward + -myTransform.up).normalized);
        }
    }
}
