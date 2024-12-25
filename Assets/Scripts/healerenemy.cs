using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healerenemy : MonoBehaviour
{
    public float healAmount = 50f;
    public float healRadius = 2f;
    public float healCooldown = 5f;
    public ParticleSystem heal;

    private float lastHealTime = 0f;

    void Update()
    {
        // Check if it's time to heal again
        if (Time.time > lastHealTime + healCooldown)
        {
            // Find all nearby enemies
            Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, healRadius);
            foreach (Collider2D collider in nearbyColliders)
            {
                // Check if the collider belongs to an enemy
                enemymovement enemy = collider.GetComponent<enemymovement>();
                if (enemy != null )
                {
                    // Heal the enemy
                    enemy.takehealing(healAmount);
                    heal.Play();
                    
                }
            }

            // Record the time of the last heal
            lastHealTime = Time.time;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a circle to show the heal radius in the editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, healRadius);
    }
}
