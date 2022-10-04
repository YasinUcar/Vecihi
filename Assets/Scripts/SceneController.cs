using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class SceneController : MonoBehaviour
{
    float gecenZaman;
    void Update()
    {
        gecenZaman += Time.deltaTime;
        if (Keyboard.current.anyKey.isPressed && gecenZaman > 3) //new input system any key
        {
            int currenIndexScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(1);
        }
    }
}
