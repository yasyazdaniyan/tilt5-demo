using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wand_controller : MonoBehaviour
{
    private GameObject wand_prefab;
    private GameObject aim_point;
    // Start is called before the first frame update
    void Start()
    {
        wand_prefab = gameObject;
        aim_point = wand_prefab.transform.Find("aim_point").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (TiltFive.Wand.TryGetWandDevice(TiltFive.PlayerIndex.One, TiltFive.ControllerIndex.Right, out TiltFive.WandDevice wandDevice))
        {
            gameObject.transform.position = wandDevice.devicePosition.value;
            gameObject.transform.rotation = wandDevice.deviceRotation.value;
        }
        if (TiltFive.Input.GetTrigger() > 0.1)
        {
            // Define the origin of the ray (e.g., the position of the GameObject this script is attached to)
            Vector3 rayOrigin = aim_point.transform.position;

            // Define the direction of the ray (e.g., forward direction of the GameObject)
            Vector3 rayDirection = aim_point.transform.forward;

            // Set the length of the ray (how far it extends)
            float rayLength = 5f;

            // Perform the raycast
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, rayDirection, out hit, rayLength))
            {
                // If the ray hits something, visualize the hit point
                Debug.DrawLine(rayOrigin, hit.point, Color.red);
            }
            else
            {
                // If the ray doesn't hit anything, visualize the full length of the ray
                Debug.DrawRay(rayOrigin, rayDirection * rayLength, Color.green);
            }
        }
    }
}
