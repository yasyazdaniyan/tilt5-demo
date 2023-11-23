using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeOnCollision : MonoBehaviour
{
    public GameObject smokeParticleSystem;
    public GameObject cube;
    public GameObject building;

    private bool hasCollided = false;

    void Start()
    {
        smokeParticleSystem.SetActive(false);
    }

    void Update()
    {

        if (cube != null && building != null)
        {
            float distance = Vector3.Distance(cube.transform.position, building.transform.position);
            Debug.Log(distance);
            if (distance < 5.0f)
            {
                Debug.Log("Collided");
                smokeParticleSystem.SetActive(true);
                cube.SetActive(false);
                hasCollided = true;
            }

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Building") && !hasCollided)
        {
            Debug.Log("Collided");
            smokeParticleSystem.SetActive(true);
            hasCollided = true;
        }
    }
}
