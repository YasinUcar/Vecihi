using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip fireballClip;

    [SerializeField] AudioClip explosionClip;
    [SerializeField] AudioClip lostGame, winGame;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void PlayFireBallClip()
    {
        AudioSource.PlayClipAtPoint(fireballClip, Camera.main.transform.position, 1f);
    }
    public void PlayExplosion()
    {
        AudioSource.PlayClipAtPoint(explosionClip, Camera.main.transform.position, 1f);
    }
    public void PlayLostGame()
    {
        AudioSource.PlayClipAtPoint(lostGame, Camera.main.transform.position, 1.3f);
        
        
    }
    public void PlayWinGame()
    {
        AudioSource.PlayClipAtPoint(winGame, Camera.main.transform.position, 1.3f);
    }
}
