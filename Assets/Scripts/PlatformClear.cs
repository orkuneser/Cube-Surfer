using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformClear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        #region LEVEL CLEAR SYSTEM
        if (other.gameObject.tag=="Platform")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag=="Wall")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "block")
        {
            Destroy(other.gameObject);
        }
        #endregion
    }
}
