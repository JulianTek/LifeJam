using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform center;   // The center of the circle around which the camera will move
    public float radius = 5f;  // The radius of the circle
    public float rotationSpeed = 20f; // Speed of rotation in degrees per second

    private Vector3 cameraPosition;

    private void Start()
    {
        if (center == null)
        {
            Debug.LogError("Please assign the 'center' variable with the center of the circle (usually an empty GameObject).");
            enabled = false; // Disable the script to avoid errors
            return;
        }

        cameraPosition = transform.position - center.position;
    }

    private void Update()
    {
        // Rotate the camera around the center of the circle
        transform.RotateAround(center.position, Vector3.up, rotationSpeed * Time.deltaTime);

        // Calculate the new camera position based on the updated rotation
        Vector3 desiredPosition = Quaternion.Euler(0f, rotationSpeed * Time.deltaTime, 0f) * cameraPosition;
        transform.position = center.position + desiredPosition;
    }
}
