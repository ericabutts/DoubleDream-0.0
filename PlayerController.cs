using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        //mouse look
    public enum RotationAxes {
    MouseXAndY = 0,
    MouseX = 1,
    MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;
    private float rotationX = 0;

    public Vector3 moveDirection;
    public int speed = 6;
    public float gravity = -9.8f;
    public CharacterController controller;
    public float MoveSpeed;
    public float RotateSpeed;

    public Camera cam;

    Vector3 playerTransform;
    public Vector3 cameraTransform;
    public Vector3 offset;

    public bool playerActive;

    public void ActivatePlayer() {
        Debug.Log("player is now active");
        GetComponent<RayShooter>().raycastActive = true;
        playerActive = true;
    }
    void Start() {
        playerActive = false;
       
    }
    void Update()
    {
        MoveThePlayer();
        CameraFollow(); 
        
        
    }

    void MoveThePlayer() {
            if (axes==RotationAxes.MouseX) {
    transform.Rotate(0,Input.GetAxis("Mouse X") * sensitivityHor, 0);
    
    }
        else if (axes==RotationAxes.MouseY) {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(rotationX,rotationY,0);


        }

        else {

            rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            rotationX = Mathf.Clamp(rotationX,minimumVert,maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(rotationX, rotationY,0);
        }
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;
        moveDirection.y = gravity;

        controller.Move(moveDirection);


    }

    void CameraFollow() {
        // Debug.Log(offset);
        cameraTransform = playerTransform + offset;
    }
}
