using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject fireBall;
    [SerializeField] float fireSpeed = 10f;

    [SerializeField] float randomnextFireBallmin = 0.5f;
    [SerializeField] float randomnextFireBallmax = 1f;
    [SerializeField] bool useAI;
    [HideInInspector] public bool isFiring;

    PlayerController player;
    AudioPlayer audioPlayer;

    Coroutine firingCoroutine;

    string gameObjectTag;
    void Awake()
    {
        player = GetComponent<PlayerController>();
        audioPlayer = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioPlayer>();

    }
    void Start()
    {

        gameObjectTag = gameObject.tag;
    }

    void Update()
    {
        Fire();
        if (useAI && transform.position.x <= 7)
        {
            isFiring = true;
            GetComponent<Collider2D>().enabled = true;
        }
    }
    public void Fire()
    {
        if (isFiring && firingCoroutine == null)
            firingCoroutine = StartCoroutine(FireCoroutine());
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }
    public IEnumerator FireCoroutine()
    {

        while (true)
        {
            GameObject copy = Instantiate(fireBall, transform.position, Quaternion.identity);
            copy.GetComponent<Rigidbody2D>().velocity = transform.right * fireSpeed;
            Destroy(copy, 5f);
            float randomnextFireBall = Random.Range(randomnextFireBallmin, randomnextFireBallmax);
            if (audioPlayer != null)
                audioPlayer.PlayFireBallClip();
            yield return new WaitForSeconds(randomnextFireBall);
        }
    }

}
