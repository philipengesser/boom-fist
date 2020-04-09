using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraPivot : MonoBehaviour
{

    public Transform CameraPivotTransform;
    public Transform CameraLocationTarget;
    public float ComeraRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraPivotTransform.localEulerAngles = new Vector3(CameraPivotTransform.localEulerAngles.x + Input.GetAxis("Mouse Y") * ComeraRotationSpeed * -1,
            CameraPivotTransform.localEulerAngles.y + Input.GetAxis("Mouse X") * ComeraRotationSpeed, 0);
    }

    [ExecuteInEditMode]
    private void LateUpdate()
    {
        CameraPivotTransform.position = CameraLocationTarget.position;
    }
}
