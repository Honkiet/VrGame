using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuosMovement : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    private XRRig rig; // for headmovement 
    [SerializeField] float speed = 1f;
    [SerializeField] float rigSpeed; //TODO later automatic movement along 
    private float fallingSpeed;
    [SerializeField] Transform target;

    [SerializeField] float additionalHeight = 0.2f;

    // Inputs
    [SerializeField] XRNode inputSource;
    private Vector2 inputAxis;

    // Moving the Rig
    private CharacterController character;
    [SerializeField] float gravity = -9.81f;

    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    // Update is called once per frame
    void Update()
    {
        //Getting Input through InputDevices and using the (Joysticks=primary2DAxis) Value in inputAxis
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        // Head Movement, might delete later
        //Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        //Movement in playspace
        CapsuleFollowHeadset();


        // Moving 

        MoveTowardsTarget(target);
        //Vector3 direction = new Vector3(inputAxis.x, 0, inputAxis.y);

        //character.Move(direction * Time.fixedDeltaTime * speed);


        //gravity
        bool isGrounded = CheckIfGrounded();
        if (isGrounded)
        {
            fallingSpeed = 0;
        }
        else
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
            character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
        }
        
    }

    private void CapsuleFollowHeadset() // moving in play space ?
    {
        character.height = rig.cameraInRigSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.z);
    }

    private bool CheckIfGrounded()
    {
        //tells us if on ground
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }

    void MoveTowardsTarget(Transform target)
    {
        
        var offset = target.position - transform.position; // Is transform.position rght ?
        //Get the difference.
        if (offset.magnitude > .1f)
        {
            offset = offset.normalized * speed;
            character.Move(offset * Time.deltaTime);

        }
    }
}
