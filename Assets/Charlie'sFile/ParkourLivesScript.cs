using System.Runtime.CompilerServices;
using UnityEngine;

public class ParkourLivesScript : MonoBehaviour
{
    //I attached this to the player capsule model thing, and not the canvas
    //We can change max health/Max health in game
    public int _currentHealth = 3;
    public int _maxHealth = 3;
    public bool _isDead = false;


    //For Gamestate, will check if you have no health. 
    private void Update()
    {
        if(_currentHealth <= 0)
        {
            _isDead = true;
        }
    }

    //Resets the health back to the max
    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }

    //Heals for one
    public void Heal()
    {
        if(_currentHealth < _maxHealth)
        {
            _currentHealth++;
        }
    }

    //Take one damage
    public void TakeDamage()
    {
        if(_currentHealth > 0)
        {
            _currentHealth--;
        }
    }
}
