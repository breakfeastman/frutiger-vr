using UnityEngine;

public class TabSystem : MonoBehaviour
{
    public GameObject[] tabObjects;
    public string handTag = "HandTag";

    private int currentTab = 0;

    private void Start()
    {
        SetActiveTab(currentTab);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(handTag))
        {
            SwitchToNextTab();
        }
    }

    private void SwitchToNextTab()
    {
        SetActiveTab((currentTab + 1) % tabObjects.Length);
    }

    public void SwitchToPreviousTab()
    {
        SetActiveTab((currentTab + tabObjects.Length - 1) % tabObjects.Length);
    }

    private void SetActiveTab(int tabIndex)
    {
        for (int i = 0; i < tabObjects.Length; i++)
        {
            if (i == tabIndex)
            {
                tabObjects[i].SetActive(true);
            }
            else
            {
                tabObjects[i].SetActive(false);
            }
        }

        currentTab = tabIndex;
    }
}
