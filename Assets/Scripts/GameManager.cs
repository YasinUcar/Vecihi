using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject[] enemys;
    [SerializeField] GameObject AllEnemys;
    [SerializeField] GameObject torpedo;
    [SerializeField] GameObject triggerAmmo, medkit;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] GameObject player;
    bool caldiMi = false;
    private int currentEnemyCount = 0;
    float time = 10f;
    float maxWidth;
    Ammo ammo;
    Health health;
    ChildCount childCount;
    AudioPlayer audioPlayer;

    void Start()
    {
        ScreenWidthHeight();
        StartCoroutine(SpawnTorpedo());
        StartCoroutine(SpawnAmmo());
        StartCoroutine(SpawnHealth());
        ammo = GameObject.FindGameObjectWithTag("Player").GetComponent<Ammo>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        childCount = GameObject.FindGameObjectWithTag("AllEnemys").GetComponent<ChildCount>();
        audioPlayer = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioPlayer>();

    }
    void Update()
    {
        ElapsedTime();
        AnyEnemys();
        GameOverHealth();


    }
    void NewEnemySpawner()
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].transform.position = Vector2.Lerp(enemys[i].transform.position,
                       new Vector2(enemys[i].transform.position.x + -5f, 0), 5f);
        }
    }
    IEnumerator SpawnTorpedo()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 5f), transform.position.y, 0);
            Instantiate(torpedo, spawnPosition, Quaternion.Euler(new Vector3(0, 0, -90)));
            yield return new WaitForSeconds(Random.Range(2f, 3f));
        }
    }
    IEnumerator SpawnAmmo()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 5f), transform.position.y, 0);
            Instantiate(triggerAmmo, spawnPosition, Quaternion.Euler(new Vector3(0, 0, -90)));
            yield return new WaitForSeconds(Random.Range(5f, 15f));
        }
    }
    IEnumerator SpawnHealth()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 4.5f), transform.position.y, 0);
            Instantiate(medkit, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(10f, 20));
        }
    }
    void ScreenWidthHeight()
    {

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0);
        Vector3 targetWidth = Camera.main.ScreenToWorldPoint(upperCorner);
        float ballWidth = torpedo.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
    }
    void ElapsedTime()
    {
        if (time <= Mathf.Epsilon)
        {
            time = 10f;
            ammo.IncreaseCurrentAmmo(10);
            if (health != null)
                health.IncreaseCurrentHealth(50);
            NewEnemySpawner();
        }
        time -= Time.deltaTime;
        timeText.text = Mathf.RoundToInt(time).ToString();
    }
    void AnyEnemys()
    {
        if (childCount.GetChildsNumber() <= 10)
        {
            if (!caldiMi)
            {
                audioPlayer.PlayWinGame();
                caldiMi = true;
            }

            GameOver("Win GAME!");
        }
    }
    void GameOver(string winOrLost)
    {
        torpedo.SetActive(false);
        triggerAmmo.SetActive(false);
        medkit.SetActive(false);
        AllEnemys.SetActive(false);
        GameOverCanvas.SetActive(true);
        gameOverText.text = winOrLost;
    }
    void GameOverHealth()
    {
        if (health.GetHealth() <= 0)
        {

            if (!caldiMi)
            {
                audioPlayer.PlayLostGame();
                caldiMi = true;
            }
            GameOver("Game Over!");
        }

    }

}
