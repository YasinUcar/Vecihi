using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject gameOver;
    [Header("BoundsPaddings")]
    float paddingLeft = 0.80f;
    float paddingRight = 0.80f;

    Vector2 minBounds;
    Vector2 maxBounds;
    Vector2 rawInput;
    Shooter shooter;
    Ammo ammo;
    void Awake()
    {
        shooter = GetComponent<Shooter>();
        ammo = GetComponent<Ammo>();
        gameOver.SetActive(false);
        Time.timeScale = 1;
    }
    void Start()
    {
        MovementBounds();

    }
    void Update()
    {
        Move();
        AmmoControl();
    }
    void MovementBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingLeft, maxBounds.y - paddingRight);
        transform.position = newPos;

    }
    private void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
    private void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
            ammo.ReduceCurrentAmmo();
            print(shooter.isFiring);
        }
    }
    private void AmmoControl()
    {
        if (ammo.GetAmmo() <= 0)
        {

            shooter.StopCoroutine(shooter.FireCoroutine());
            shooter.enabled = false;
            ammo.currentAmmo = 0;
            ammo.GetAmmo();
        }

        if ((ammo.GetAmmo() >= 1))
        {
            shooter.enabled = true;
            shooter.Fire();

        }
        ammo.GetAmmo();

    }
}
