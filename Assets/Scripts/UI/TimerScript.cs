using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(Time.time);
        timerText.text = timeSpan.ToString(@"mm\:ss");
    }
}
