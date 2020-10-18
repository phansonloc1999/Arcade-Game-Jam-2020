using UnityEngine;

public static class PlayerHealth
{
    private static int MAX_HEALTH = 100;
    private static int _currentHealth = MAX_HEALTH;

    public static void TakeDamage(int ammount)
    {
        _currentHealth -= ammount;

        Debug.Log("Player health is " + _currentHealth);
    }
}