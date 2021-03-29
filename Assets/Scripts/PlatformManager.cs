using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        #region ENDLESS LEVEL SYSTEM
        if (other.gameObject.tag=="Player")
        {
            // Create New Platform
            LevelManager.instance.CreatePlatform();
            
            // Create New Block
            LevelManager.instance.blockMaxPosZ += 100;
            LevelManager.instance.blockMinPosZ += 100;
            LevelManager.instance.Createblock();

            // Create New Wall
            LevelManager.instance.wallMaxPosZ += 100;
            LevelManager.instance.wallMinPosZ += 100;
            LevelManager.instance.CreateWall();
        }
        #endregion

    }

}
