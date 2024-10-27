using System;
using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript InstancePlayerAttributes { get; set; }
    private int health = 100;
    private int maxHealth = 100;
    public event Action<int> Damage = delegate { };
    public event Action Dead = delegate { };
    private void Awake()
    {
        if (InstancePlayerAttributes == null)
        {
            InstancePlayerAttributes = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int getHealth()
    {
        if (health <= 0)
        {
            health = 0;
            Dead.Invoke();
        }
        return health;
    }

    public void TakeDamage(int amount)
    {
        if (health <= 0)
        {
            health = 0;
            Dead.Invoke();
        }
        else if (health > 0)
        {
            health -= amount;
            Damage.Invoke(amount);
        }
    }

}
