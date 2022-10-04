using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] bool applyCameraShake;
    [SerializeField] Slider healthBarSlider;
    [SerializeField] GameObject hitEffect;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioPlayer>();
        healthBarSlider.maxValue = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.GetComponent<Damage>();
        if (damage != null)
        {
            TakeDamage(damage.GetDamage());
            ShakeCamera();
            PlayHitEffect();
        }
    }
    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= Mathf.Epsilon)
        {
            Destroy(this.gameObject);
        }
        if (healthBarSlider != null)
        {
            healthBarSlider.value = health;
        }
    }
    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
            if (audioPlayer != null)
                audioPlayer.PlayExplosion();
        }
    }
    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            GameObject instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, 0.5f);
        }
    }
    public void IncreaseCurrentHealth(int addHealth)
    {
        health += addHealth;
    }
    public int GetHealth()
    {
        healthBarSlider.value = health;
        return health;

    }
}
