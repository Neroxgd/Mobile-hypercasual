using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private int playerMaxHealth = 100;
    private int playerCurrentHealth;

    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void SetHealth(int amount)
    {
        playerCurrentHealth -= amount;
        healthBar.fillAmount = (float)playerCurrentHealth / (float)playerMaxHealth;
        if (playerCurrentHealth <= 0)
            Lose();
    }

    private void Lose()
    {

    }
}
