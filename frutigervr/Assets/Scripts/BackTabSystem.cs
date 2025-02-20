using UnityEngine;

public class BackTabSystem : MonoBehaviour
{
    public TabSystem tabSystemToControl;
    public string handTag = "HandTag";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(handTag))
        {
            // Switch to the previous tab
            tabSystemToControl.SwitchToPreviousTab();
        }
    }
}
