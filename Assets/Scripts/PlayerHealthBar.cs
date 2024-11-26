using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
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
        if (playerCurrentHealth <= 0)
            Lose();
    }

    private void Lose()
    {
        pauseMenu.SetActive(true);
    }
}
