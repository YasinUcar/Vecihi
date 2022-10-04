using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAmmo : MonoBehaviour
{
    Ammo ammo;
    void Start()
    {
        ammo = GameObject.FindGameObjectWithTag("Player").GetComponent<Ammo>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        ammo.IncreaseCurrentAmmo(10);
        Destroy(this.gameObject);
    }
}
