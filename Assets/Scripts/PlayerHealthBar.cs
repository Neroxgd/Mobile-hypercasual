using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar, damageBloodOverlay;
    [SerializeField] private float playerMaxHealth = 100;
    [SerializeField] private GameObject pauseMenu;
    private float playerCurrentHealth;

    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void SetHealth(float amount)
    {
        playerCurrentHealth -= amount;
        healthBar.fillAmount = playerCurrentHealth / playerMaxHealth;
        damageBloodOverlay.DOFade(1, 0.2f).OnComplete(() => damageBloodOverlay.DOFade(Mathf.Abs(healthBar.fillAmount - 1f), 0.2f));
        if (playerCurrentHealth <= 0)
            Lose();
    }

    private void Lose()
    {
        pauseMenu.SetActive(true);
    }
}
