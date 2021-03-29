using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region GAMEOBJECT VARIABLES
    public GameObject playerObj;
    public GameObject blockTransform;
    public GameObject blockObj;
    #endregion

    #region BLOCKS LIST
    public List<GameObject> blocks;
    #endregion

    #region OTHER VARIABLES
    //private bool isActive;
    public Transform Player;
    #endregion

    #region COLOR COUNTER
    [Header("BLUE BLOCKS")]
    public List<GameObject> BlueBlocks;
    [Header("YELLOW BLOCKS")]
    public List<GameObject> YellowBlocks;
    [Header("RED BLOCKS")]
    public List<GameObject> RedBlocks;
    [Header("PURPLE BLOCKS")]
    public List<GameObject> PurpleBlocks;
    [Header("GREEN BLOCKS")]
    public List<GameObject> GreenBlocks;
    private int purple, blue, red, yellow, green;
    #endregion

    //SINGLETON
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        #region BLOCK TRIGGER
        if (other.gameObject.tag == "Purple" || other.gameObject.tag == "Blue" || other.gameObject.tag == "Red" || other.gameObject.tag == "Yellow" || other.gameObject.tag == "Green")
        {
            
            switch (other.gameObject.tag)
            {
                case "Purple":
                    purple++;
                    PurpleBlocks.Add(other.gameObject);
                    other.gameObject.tag = "PurpleParent";
                    break;
                case "Blue":
                    blue++;
                    BlueBlocks.Add(other.gameObject);
                    other.gameObject.tag = "BlueParent";
                    break;
                case "Red":
                    red++;
                    RedBlocks.Add(other.gameObject);
                    other.gameObject.tag = "RedParent";
                    break;
                case "Yellow":
                    yellow++;
                    YellowBlocks.Add(other.gameObject);
                    other.gameObject.tag = "YellowParent";
                    break;
                case "Green":
                    green++;
                    GreenBlocks.Add(other.gameObject);
                    other.gameObject.tag = "GreenParent";
                    break;
                default:
                    break;
            }

            //isActive = true;
            //Destroy(other.gameObject);
            playerObj.transform.position += new Vector3(0, 1, 0);

            #region BLOCK TRANSFORM ADD
            //Block Position
            other.gameObject.transform.parent = Player.transform.parent;
            other.gameObject.transform.position = blockTransform.transform.position;

            //Camera Position
            CameraManager.instance.cameraPosZ -= 1;
            CameraManager.instance.offSet = new Vector3(3, 3, CameraManager.instance.cameraPosZ);
            #endregion

            #region BLOCK INSTANTIATE in PLAYER PARENT
            //if (isActive)
            //{
            //    other.tag = "CubeParents";
            //    var block = Instantiate(other.gameObject, blockTransform.transform.position, Quaternion.identity);

            //    block.transform.parent = Player.transform.parent;

            //    CameraManager.instance.cameraPosZ-=1;
            //    CameraManager.instance.offSet = new Vector3(3,3,CameraManager.instance.cameraPosZ);
            //}
            #endregion

            #region Block Count Controller
            if (PurpleBlocks.Count>=1 && GreenBlocks.Count>=1 && RedBlocks.Count>=1 && BlueBlocks.Count>=1 && YellowBlocks.Count>=1)
            {
                Destroy(PurpleBlocks[0]);
                PurpleBlocks.Remove(PurpleBlocks[0]);

                Destroy(YellowBlocks[0]);
                YellowBlocks.Remove(YellowBlocks[0]);

                Destroy(BlueBlocks[0]);
                BlueBlocks.Remove(BlueBlocks[0]);

                Destroy(GreenBlocks[0]);
                GreenBlocks.Remove(GreenBlocks[0]);

                Destroy(RedBlocks[0]);
                RedBlocks.Remove(RedBlocks[0]);

                //Camera Position
                CameraManager.instance.cameraPosZ += 1;
                CameraManager.instance.offSet = new Vector3(3, 3, CameraManager.instance.cameraPosZ);
            }
            #endregion
        }
        #endregion
    }
    private void LateUpdate()
    {
        //Camera Default Properties Control
        if (PurpleBlocks.Count==0 && YellowBlocks.Count==0 && BlueBlocks.Count==0 && RedBlocks.Count==0 && GreenBlocks.Count==0)
        {
            CameraManager.instance.cameraPosZ = -15;
            CameraManager.instance.offSet = new Vector3(3, 3, CameraManager.instance.cameraPosZ);
        }
    }


    #region BLOCK STAY CONTROL
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "block" || other.gameObject.tag == "CubeParents")
    //    {
    //        isActive = false;
    //    }


    //}
    #endregion
}
