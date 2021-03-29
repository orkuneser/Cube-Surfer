using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region TARGET and  SPEED VARIABLES
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed;
    #endregion

    #region VARIABLES
    public Vector3 offSet;
    public float cameraPosZ;
    #endregion

    #region SINGLETON VARIABLES
    public static CameraManager instance;
    #endregion

    private void Awake()
    {
        #region CAMERA SINGLETON
        if (instance!=null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            instance = this;
        }
        #endregion
    }
    private void Start()
    {
        #region CAMERA DEFAULT PROPERTIES
        cameraPosZ = -15;
        offSet = new Vector3(3,3,cameraPosZ);
        #endregion
    }
    private void FixedUpdate()
    {
        #region CAMERA GAMEPLAY MOVEMENT
        Vector3 desiredPosition = target.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);
        transform.position = smoothedPosition;
        #endregion
    }


}
