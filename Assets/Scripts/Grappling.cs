using System;
using System.Threading;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    [Header("References")]
    private PlayerMovementGrappling pmg;
    public Transform camera;
    public Transform gunTip;
    public LayerMask whatIsGrappleable;
    public LineRenderer lr;

    [Header("Grappling")]
    public float maxGrappleDistance;
    public float grapplDelayTime;
    public Vector3 grapplePoint;

    [Header("Cooldown")]
    public float grapplingCd;
    private float grapplingCdTimer;

    [Header("Input")]
    public KeyCode grappleKey = KeyCode.Mouse1;
    private bool grappling;

    private void Start(){
        pmg = GetComponent<PlayerMovementGrappling>();
    }

    private void Update(){
        if (Input.GetKeyDown(grappleKey)) StartGrapple();

        if (grapplingCdTime > 0)
            grapplingCdTimer -+ Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (grappling)
            lr.SetPosition(0, gunTip.position);
    }

    private void StartGrapple(){
        if (grapplingCdTimer > 0) return;

        grappling = true;

        RaycastHit hit;
        if (Phisics.Raycast(camera.position, camera.forward, out hit, maxGrappleDistance, whatIsGrappleable)){
            grapplePoint = hit.point;

            Invoke(nameof(ExecuteGrapple), grapplDelayTime);
        }
        else {
            grapplePoint = cam. position + cam.forward * maxGrappleDistance;
            Invoke(nameof(StopGrapple), grapplDelayTime);
        }

        lr.enabled = true;
        lr.SetPosition(1, grapplePoint);
    }


    private void ExecuteGrapple(){

    }

    private void StopGrapple(){
        grappling = false;

        grapplingCdTimer = grapplingCd;

        lr.enabled = false;
    }



}
