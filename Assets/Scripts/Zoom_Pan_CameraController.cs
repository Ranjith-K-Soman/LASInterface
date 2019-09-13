using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom_Pan_CameraController : MonoBehaviour
{
    public float turnSpeed = 4.0f;         // Speed of camera turning when mouse moves in along an axis
    public float panSpeed = 2.0f;			// Speed of the camera when being panned
    private float moveSpeed = 1f;
    private float scrollSpeed = 20f;

    private Vector3 mouseOrigin;    // Position of cursor when mouse dragging starts
    private bool isPanning;     // Is the camera being panned?
    private bool isRotating;	// Is the camera being rotated?
    private bool isZooming;
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Vector3 pos = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            Vector3 move = new Vector3(pos.x * panSpeed/5, 0, pos.z * panSpeed/5);
            transform.Translate(move, Space.Self);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {

            Vector3 pos = new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel"));


            Vector3 move = pos.z * scrollSpeed * transform.forward;
            transform.Translate(move, Space.World);

        }

        

        // Get the right mouse button
        if (Input.GetMouseButtonDown(1))
        {

            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isRotating = true;
            
        }

        // Get the middle mouse button
        if (Input.GetMouseButtonDown(2))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }

        // Disable movements on button release
        if (!Input.GetMouseButton(1)) isRotating = false;
        if (!Input.GetMouseButton(2)) isPanning = false;
        //if(Input.GetAxis("Mouse ScrollWheel") == 0) isZooming = false;

        // Rotate camera along X and Y axis
        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
        }

        // Move the camera on it's XY plane
        if (isPanning)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
            transform.Translate(move, Space.Self);
        }

    

    }
}

