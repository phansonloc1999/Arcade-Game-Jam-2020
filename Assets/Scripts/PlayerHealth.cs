using UnityEngine;

public static class PlayerHealth
{
    private static int MAX_HEALTH = 10;

    private static int _currentHealth = MAX_HEALTH;
    public static int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }

    public delegate void PlayerTakingDamageHandler();
    public static event PlayerTakingDamageHandler OnPlayerTakingDamage;


    public static void TakeDamage(int ammount)
    {
        CurrentHealth = Mathf.Max(CurrentHealth - ammount, 0);

        Debug.Log("Player health is " + CurrentHealth);

        OnPlayerTakingDamage?.Invoke();
    }
}