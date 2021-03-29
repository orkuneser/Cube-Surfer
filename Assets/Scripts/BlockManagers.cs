using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManagers : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        #region BLOCK TRIGGER CONTROL
        if (other.gameObject.tag=="Wall")
        {
            transform.parent = null;
            switch (this.gameObject.tag)
            {
                case "PurpleParent":
                    GameManager.instance.PurpleBlocks.Remove(GameManager.instance.PurpleBlocks[0]);
                    break;
                case "BlueParent":
                    GameManager.instance.BlueBlocks.Remove(GameManager.instance.BlueBlocks[0]);
                    break;
                case "GreenParent":
                    GameManager.instance.GreenBlocks.Remove(GameManager.instance.GreenBlocks[0]);
                    break;
                case "RedParent":
                    GameManager.instance.RedBlocks.Remove(GameManager.instance.RedBlocks[0]);
                    break;
                case "YellowParent":
                    GameManager.instance.YellowBlocks.Remove(GameManager.instance.YellowBlocks[0]);
                    break;
                default:
                    break;
            }

            StartCoroutine(DestroyBlock());
            CameraManager.instance.cameraPosZ += 0.2f;
            CameraManager.instance.offSet = new Vector3(3, 3, CameraManager.instance.cameraPosZ);
        }
        #endregion
    }

    IEnumerator DestroyBlock()
    {
       yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
