using UnityEngine;
using TMPro;

public class TimeDisplay12HR : MonoBehaviour
{
    public TextMeshPro timeText;

    void Update()
    {
        System.DateTime currentTime = System.DateTime.Now;

        string timeString = currentTime.ToString("h:mm:ss tt");

        if (timeText != null)
        {
            timeText.text = timeString;
        }
    }
}
