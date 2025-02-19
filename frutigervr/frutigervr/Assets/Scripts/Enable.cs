using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    public GameObject thing;

        void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HandTag")
        {
            thing.SetActive(true);
        }
    }
}
