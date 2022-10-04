using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    Health health;
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        health.IncreaseCurrentHealth(30);
        health.GetHealth();
        Destroy(this.gameObject);
    }
}
