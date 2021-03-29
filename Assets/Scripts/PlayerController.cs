using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES 
    [SerializeField] private float controlSpeed;
    [SerializeField] private float movementSpeed;
    
    private float touchPosX;
    private bool isStart;
    #endregion
    private void FixedUpdate()
    {
        PlayerMovement();
    }


    #region PLAYER MOVEMENT CONTROLLER
    private void PlayerMovement()
    {
        // Player Forward Movement
        transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;

        // Player Controller
        if (Input.GetMouseButton(0))
        {
            touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
        }

        transform.position = new Vector3(touchPosX,transform.position.y,transform.position.z);


        // Clamp
        float xPos = Mathf.Clamp(transform.position.x, -0.72f, 6.28f);
        transform.position = new Vector3(xPos,transform.position.y,transform.position.z);
    }
    #endregion
}
