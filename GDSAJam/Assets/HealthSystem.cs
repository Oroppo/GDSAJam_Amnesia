using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthSystem : MonoBehaviour
{
    public int MaxHealth = 3, CurrentHealth = 3;
    public bool Invulnerable = false;
    public Timer timer;
    public Transform Board;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        if (Invulnerable)
            return;
        Invulnerable = true;
        Invoke(nameof(ResetInvulnerability), 1.0f);
        CurrentHealth -= damage;

        for (int i = 0; i < 3; i++)
            Board.GetChild(i).gameObject.SetActive(false);
        for (int i = 0; i < CurrentHealth; i++)
            Board.GetChild(i).gameObject.SetActive(true);

        if (CurrentHealth <= 0)
        {
            timer.Die();
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
          
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
