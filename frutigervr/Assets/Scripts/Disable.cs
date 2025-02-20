using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public GameObject thing;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HandTag")
        {
            thing.SetActive(false);
        }
    }
}
