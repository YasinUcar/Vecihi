using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderEnemy : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<realEnemy>().enabled == true)
        {
            print("tetiklendi");
            gameOver.SetActive(true);

        }

    }
}
