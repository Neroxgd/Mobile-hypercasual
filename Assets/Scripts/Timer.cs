using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    [SerializeField] private PlayerHealthBar playerHealthBar;
    [SerializeField] private int timerCount = 60;
    private int currentCount;

    private void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();

        currentCount = timerCount;
        StartCoroutine(Watch());
    }

    private IEnumerator Watch()
    {
        yield return new WaitForSeconds(1);
        currentCount -= 1;
        timerText.text = currentCount / 60 + ":" + (currentCount % 60).ToString("00");
        if (currentCount <= 0)
        {
            playerHealthBar.Lose();
            yield break;
        }
        StartCoroutine(Watch());
    }
}
