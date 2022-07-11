using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    private float maxDistance = 100f;
    private SpringJoint joint;
    private Rigidbody rb;
    private float thrust = 0.4f;

    // public LayerMask grappleAbble; if we ever decide to add non-grappleable things

    public Transform shootingPoint, FPCamera, player;

    void Awake() 
    {
        lr = GetComponent<LineRenderer>();
        rb = player.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // start grappling
            StartGrapple();
        }
        // if the left mouse button is let go of
        else if (Input.GetMouseButtonUp(0))
        {
            // stop grappling
            StopGrapple();
        }
    }

    void LateUpdate()
    {
        DrawRope();
    }
    
    void FixedUpdate()
    {
        PushToGrapplePoint();
    }


    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.position, FPCamera.forward, out hit, maxDistance)) //, grappleAbble)) if we ever decide to add ungrappleabble things
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceToGrapplePoint = Vector3.Distance(player.position, grapplePoint);

            // Need to play around with these a bit
            joint.maxDistance = distanceToGrapplePoint * 0.8f;
            joint.minDistance = distanceToGrapplePoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);

    }

    void DrawRope()
    {
        // return if the rope should not exist
        if (!joint) return;

        lr.SetPosition(0, shootingPoint.position);
        lr.SetPosition(1, grapplePoint);
    }

    void PushToGrapplePoint()
    {
        // return if the rope does not exist
        if (!joint) return;

        rb.AddForce((grapplePoint - player.position) * thrust, ForceMode.Impulse);
    }

    public bool IsGrappling()
    {
        return (joint != null);
    }

    public Vector3 GetGrapplePoint() 
    {
        return grapplePoint;
    }
}
