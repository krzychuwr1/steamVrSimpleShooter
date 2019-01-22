using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR;

public class ShootingScript : MonoBehaviour {

    public Rigidbody projectilePrefab;
    public float projectileSpeed;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        shoot(SteamVR_Input_Sources.LeftHand, SteamVR_Input._default.inActions.SkeletonLeftHand);
        shoot(SteamVR_Input_Sources.RightHand, SteamVR_Input._default.inActions.SkeletonRightHand);
        //if (SteamVR_Input._default.inActions.GrabPinch.GetState(SteamVR_Input_Sources.RightHand))
        //{
        //    //var rightCoords = SteamVR_Input._default.inActions.SkeletonLeftHand.GetBonePositions(SteamVR_Input_Sources.RightHand);
        //    var rightCoords = SteamVR_Input._default.inActions.Pose.GetLastLocalPosition(SteamVR_Input_Sources.RightHand);
        //    //var rightRotation = SteamVR_Input._default.inActions.Pose.GetLocalRotation(SteamVR_Input_Sources.RightHand);
        //    var rightRotation =  SteamVR_Input._default.inActions.SkeletonRightHand.GetLastLocalRotation(SteamVR_Input_Sources.RightHand);
        //    var newProjectile = Instantiate(projectilePrefab, rightCoords, Quaternion.identity);
        //    newProjectile.velocity = rightRotation * Quaternion.Euler(45, 0, 90) * new Vector3(0, 0, 3);
        //    Debug.Log(rightCoords[0]);
        //    Debug.Log(rightCoords[1]);
        //    Debug.Log(rightCoords[2]);
        //    print("right trigger down");
        //}
    }

    private void shoot(SteamVR_Input_Sources source, SteamVR_Action_Skeleton skeleton)
    {
        if (SteamVR_Input._default.inActions.GrabPinch.GetState(source))
        {
            //SteamVR_Input._default.outActions.Haptic.Execute(0, 1, 320, 1f, source);
            var coords = SteamVR_Input._default.inActions.Pose.GetLastLocalPosition(source);
            var rotation = skeleton.GetLastLocalRotation(source);
            var newProjectile = Instantiate(projectilePrefab, coords, Quaternion.identity);
            newProjectile.tag = "projectile";
            newProjectile.velocity = rotation * Quaternion.Euler(45, 0, 90) * new Vector3(0, 0, projectileSpeed);
        }
    }
}
