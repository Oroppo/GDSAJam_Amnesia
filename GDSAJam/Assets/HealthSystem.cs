using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthSystem : MonoBehaviour
{
    public int MaxHealth = 3, CurrentHealth = 3;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth<=0)
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
    public void Heal(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
    }
}
