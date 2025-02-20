using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyClickRemake : MonoBehaviour
{
    [Header("Assign Values:")]
    public Material Red;
    public Material White;
    public AudioSource audioSource;
    public AudioClip clickSFX;
    [Space]
    [Header("Optional:")]
    public float TimedTime = 1;
    [Space]
    [Header("Debugging:")]
    public bool DebugClick;
    private Renderer rend;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
        rend.material = White;
    }

    // Update is called once per frame
    void Update()
    {
       if(DebugClick == true)
        {
            audioSource.PlayOneShot(clickSFX);
            StartCoroutine(changecolor());
            DebugClick = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("HandTag"))
        {
            audioSource.PlayOneShot(clickSFX);
            StartCoroutine(changecolor());
        }
    }
    IEnumerator changecolor()
    {
        rend.material = Red;
        yield return new WaitForSeconds(TimedTime);
        rend.material = White;
    }

}
