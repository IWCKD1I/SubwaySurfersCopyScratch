using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    public float speed = 2f; // Adjust the speed as needed

    // Update is called once per frame
    void Update()
    {
        // Move the object forward based on its own forward direction
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}