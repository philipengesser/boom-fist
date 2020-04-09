using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public Transform CharacterToMove;
    public Rigidbody RigidbodyToMove;
    public Animator CharacterToAnimate;
    public Transform ThirdPersonCameraTransform;
    public Collider CharacterCollider;

    public Vector3 LastMoveVelocity;
    public float MaxMoveSpeed;
    public float TimeToMaxMoveSpeed;
    public float FractionOfMoveSpeed;
    public float ModelTurnSpeed;
    public bool Grounded;
    public float PlayerGravity;
    public float GroundCheckRadius;

    public float CharacterGroundSpeed
    {
        get { return CurrentCharacterVelocity.x + CurrentCharacterVelocity.z; }
    }

    public Vector3 CurrentCharacterVelocity;

    public LayerMask ThingsToStandOn;



    private float verticalInput;
    private float horizantalInput;

    private float baseDynamicFriction;
    private float baseStaticFriction;

    [SerializeField]
    private float totalContacts;

    private void Start()
    {
        baseDynamicFriction = CharacterCollider.material.dynamicFriction;
        baseStaticFriction = CharacterCollider.material.staticFriction;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 verticalMovement = ThirdPersonCameraTransform.forward * Input.GetAxisRaw("Vertical");
        Vector3 horizantalMovement = ThirdPersonCameraTransform.right * Input.GetAxisRaw("Horizontal");

        verticalMovement = new Vector3(verticalMovement.x, 0, verticalMovement.z);
        horizantalMovement = new Vector3(horizantalMovement.x, 0, horizantalMovement.z);

        Vector3 directionToMove = (verticalMovement + horizantalMovement).normalized;

        //print(directionToMove);

        
        //CurrentCharacterVelocity = directionToMove * MaxMoveSpeed;
        print(CurrentCharacterVelocity);
        //CurrentCharacterVelocity = new Vector3((directionToMove * MaxMoveSpeed).x, CurrentCharacterVelocity.y, (directionToMove * MaxMoveSpeed).z);

        if (verticalMovement != Vector3.zero || horizantalMovement != Vector3.zero)
        {
            CharacterToAnimate.SetBool("Running", true);
            
            //if ((directionToMove * MaxMoveSpeed).)
            //{

            //}
        }
        else
        {
            //CurrentCharacterVelocity = new Vector3(0, CurrentCharacterVelocity.y, 0);
            CharacterToAnimate.SetBool("Running", false);
        }

        


        Vector3 directionToLook = Vector3.RotateTowards(CharacterToMove.forward, directionToMove.normalized, ModelTurnSpeed * Time.deltaTime, 0);
        CharacterToMove.rotation = Quaternion.LookRotation(directionToLook);




        Vector3 groundNormalVector = new Vector3();
        RaycastHit hit = new RaycastHit();

        //Grounded
        //if (Physics.SphereCast(transform.position, GroundCheckRadius, -transform.up, out hit, 1.2f))
        //{
        //    groundNormalVector = hit.normal;
        //    RigidbodyToMove.position = new Vector3(RigidbodyToMove.position.x, hit.point.y + 1, RigidbodyToMove.position.z);
        //    CurrentCharacterVelocity = new Vector3(CurrentCharacterVelocity.x, 0, CurrentCharacterVelocity.z);
        //    Grounded = true;
        //}
        //else //Not Grounded
        //{
        //    ArgumentVelocity(0, PlayerGravity * Time.deltaTime, 0);
        //    Grounded = false;
        //}

        //CurrentCharacterVelocity = new Vector3(Input.GetAxisRaw("Horizontal") * MaxMoveSpeed, CurrentCharacterVelocity.y, Input.GetAxisRaw("Vertical") * MaxMoveSpeed);

        //if (Input.GetKey(KeyCode.Z) || Input.GetKeyDown(KeyCode.Z))
        //{
        //    CurrentCharacterVelocity = new Vector3(5, 0, 0);
        //}
        //else if (Input.GetKey(KeyCode.X) || Input.GetKeyDown(KeyCode.X))
        //{
        //    CurrentCharacterVelocity = new Vector3(0, 0, 5);
        //}
        //else
        //{
        //    CurrentCharacterVelocity = new Vector3(0, 0, 0);
        //}

        if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A))
        {
            CurrentCharacterVelocity = new Vector3(5, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.S))
        {
            CurrentCharacterVelocity = new Vector3(0, 0, 5);
        }
        else
        {
            CurrentCharacterVelocity = new Vector3(0, 0, 0);
        }


        RigidbodyToMove.MovePosition(new Vector3(RigidbodyToMove.position.x + CurrentCharacterVelocity.x * Time.deltaTime,
            RigidbodyToMove.position.y + CurrentCharacterVelocity.y * Time.deltaTime,
            RigidbodyToMove.position.z + CurrentCharacterVelocity.z * Time.deltaTime));

        //Vector3 directionFromGround = Vector3.ProjectOnPlane(directionToMove, groundNormalVector);

        //float moveSpeed = FrictonMoveSpeed + movePlus;

        //RigidbodyToMove.velocity += (directionFromGround * MoveSpeed * Time.deltaTime * FractionOfMoveSpeed);


    }


    //public float MoveInputTowardsTarget(float currentInput, float target, float acceleration)
    //{
    //    if (currentInput < target)
    //    {
    //        currentInput += acceleration * Time.deltaTime;
    //    }
            
    //    else if (currentInput > target)
    //    {
    //        currentInput -= acceleration * Time.deltaTime;
    //    }

    //    return currentInput;
    //}

    //private void OnCollisionStay(Collision collision)
    //{
    //    totalContacts += collision.contactCount;
    //}

    //public void OnCollisionEnter(Collision collision)
    //{
    //    ChangeFriction(collision.collider.material, .5f);
    //}

    //public void OnCollisionExit(Collision collision)
    //{
    //    ChangeFriction(collision.collider.material, 2f);
    //}

    public void ChangeFriction(PhysicMaterial material, float amountToTimesBy)
    {
        CharacterCollider.material.dynamicFriction = CharacterCollider.material.dynamicFriction * amountToTimesBy;
        CharacterCollider.material.staticFriction = CharacterCollider.material.staticFriction * amountToTimesBy;
    }

    public void ArgumentVelocity(float x, float y, float z)
    {
        CurrentCharacterVelocity = new Vector3(CurrentCharacterVelocity.x + x, CurrentCharacterVelocity.y +  y, CurrentCharacterVelocity.z + z);
    }
}
