using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthSystem : MonoBehaviour
{
    public int MaxHealth = 3, CurrentHealth = 3;
    public bool Invulnerable = false;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if (Invulnerable)
            return;
        Invulnerable = true;
        Invoke(nameof(ResetInvulnerability), 2.0f);
        CurrentHealth -= damage;
        if(CurrentHealth<=0)
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
    public void ResetInvulnerability()
    {
        Invulnerable = false;
    }
    public void Heal(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
    }
}
