using UnityEngine;
using DG.Tweening;
using TMPro;

public class LevelIndicator : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        text.DOFade(0, 1f).SetDelay(2f);
    }
}
