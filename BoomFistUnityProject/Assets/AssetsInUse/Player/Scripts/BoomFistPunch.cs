using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoomFistPunch : MonoBehaviour
{
    

    public float Range;
    public float ExplosionForce;

    private BoomFistAmmo boomFistAmmo;
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

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        characterController = this.GetComponent<vThirdPersonController>();
        myTransform = this.transform;
        myRigidbody = this.GetComponent<Rigidbody>();
        boomFistAmmo = this.GetComponent<BoomFistAmmo>();
    }

    public void Punch(Vector3 punchTarget)
    {
        RaycastHit hit;
        if (Physics.SphereCast(midPoint, .2f, punchTarget, out hit, Range))
        {
            Vector3 trajectory = (midPoint - hit.point).normalized;
            myRigidbody.AddForce(trajectory * ExplosionForce, ForceMode.VelocityChange);
            boomFistAmmo.Ammo -= 1;

            if (hit.collider.CompareTag("Enemy"))
            {

            }
        }
    }

    private void Update()
    {
        if (boomFistAmmo.Ammo < 0)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Punch((-myTransform.forward + -myTransform.up).normalized);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Punch((myTransform.forward + (myTransform.up / 2)).normalized);
        }
    }
}
