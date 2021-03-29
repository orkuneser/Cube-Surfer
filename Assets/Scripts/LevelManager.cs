using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region GAMEOBJECT VARIABLES
    [Header("BLOCK OBJECT LIST")]
    [SerializeField] List<GameObject> BlockObj;

    [Header("WALL PREFAB")]
    [SerializeField] GameObject wallObj;

    [Header("PLATFORM PREFAB")]
    [SerializeField] GameObject playformObj;
    private GameObject createblock;
    #endregion


    #region VARIABLES
    [Header("BLOCK MIN-MAX POSITIONS")]
    public float blockMinPosX, blockMaxPosX, blockMinPosZ, blockMaxPosZ;
    [Header("WALL MIN-MAX POSITIONS")]
    public float wallMinPosX, wallMaxPosX, wallMinPosZ, wallMaxPosZ;
   
    [Header("BLOCK and WALL COUNT")]
    public int blockCount;
    public int wallCount;

    private float platformPosZ;
    #endregion

    #region VECTOR3 VARIABLES
    [Header("BLOCK and WALL POSITION")]
    public Vector3 BlockObjPos;
    public Vector3 wallObjPos;
    #endregion

    public static LevelManager instance;
    private void Awake()
    {
        #region SINGLETON
        if (instance!=null)
        {
            Destroy(instance);
            instance = this;
            
        }
        else
        {
            instance = this;
        }
        #endregion
    }
    private void Start()
    {
        // Create Level
        Createblock();
        CreateWall();
        CreatePlatform();
    }

    #region CREATE LEVEL BLOCK
    public void Createblock()
    {
        

        for (int i = 0; i <= blockCount; i++)
        {
            // Create Random Block X and Z Positions
            float xPos = Random.Range(blockMinPosX, blockMaxPosX);
            float zPos = Random.Range(blockMinPosZ, blockMaxPosZ);

            
            BlockObjPos = new Vector3(xPos, 1, zPos);

            // Create Random Block Color Count
            int blockColor = Random.Range(0,5);

            #region BLOCK COLOR INSTANTIATE
            switch (blockColor)
            {
                case 0:
                    createblock = Instantiate(BlockObj[0], BlockObjPos, Quaternion.identity);
                    break;
                case 1:
                    createblock = Instantiate(BlockObj[1], BlockObjPos, Quaternion.identity);
                    break;
                case 2:
                    createblock = Instantiate(BlockObj[2], BlockObjPos, Quaternion.identity);
                    break;
                case 3:
                    createblock = Instantiate(BlockObj[3], BlockObjPos, Quaternion.identity);
                    break;
                case 4:
                    createblock = Instantiate(BlockObj[4], BlockObjPos, Quaternion.identity);
                    break;

                default:
                    createblock = Instantiate(BlockObj[0], BlockObjPos, Quaternion.identity);

                    break;
            }
            #endregion


        }
    }
    #endregion

    #region CREATE WALL
    public void CreateWall()
    {

        for (int i = 0; i < wallCount; i++)
        {
            // Create Random Wall X and Z Positions
            float xPos = Random.Range(wallMinPosX, wallMaxPosX);
            float zPos = Random.Range(wallMinPosZ, wallMaxPosZ);

            wallObjPos = new Vector3(xPos, 0, zPos);

            var createWall = Instantiate(wallObj, wallObjPos, Quaternion.identity);

        }
    }
    #endregion

    #region CREATE PLATFORM
    public void CreatePlatform()
    {
        platformPosZ += 100;
        Vector3 platformPosition = new Vector3(transform.position.x,transform.position.y,platformPosZ);

        var createPlatform = Instantiate(playformObj,platformPosition, Quaternion.identity);
    }
    #endregion
}
