using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockBackAttack : MonoBehaviour
{
    public Transform AttackOrigin;
    public float KnockBackForce;
    public float UpwardLuachAngle;
    public int Damage;



    private void OnTriggerEnter(Collider other)
    {
        print("Check1");
        if (other.CompareTag("Player"))
        {
            print("Check2");
            Vector3 LuanchTrajectory =  other.attachedRigidbody.position - AttackOrigin.position;
            LuanchTrajectory = new Vector3(LuanchTrajectory.x, LuanchTrajectory.y + UpwardLuachAngle, LuanchTrajectory.z);
            LuanchTrajectory = LuanchTrajectory.normalized;
            other.attachedRigidbody.AddForce(LuanchTrajectory * KnockBackForce, ForceMode.VelocityChange);
            other.GetComponent<BoomFistHP>().HP -= 1;
        }
    }
}
