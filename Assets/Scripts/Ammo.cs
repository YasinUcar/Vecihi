using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    public float currentAmmo;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] float triggerIncreaseAmmo;


    public float GetAmmo()
    {
        return currentAmmo;
    }
    public void ReduceCurrentAmmo()
    {
        currentAmmo -= 0.5f;
    }
    public void IncreaseCurrentAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
    }
    void Update()
    {
        if (ammoText != null)
            ammoText.text = "Ammo: " + Mathf.RoundToInt(currentAmmo).ToString();
    }


}
