using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] private float currentSpeed = 10.0f;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float boostSpeed = 20.0f;
    [SerializeField] private float steerSpeed = 0.5f;
    [SerializeField] private TMPro.TMP_Text boostText;

    private void Start()
    {
        boostText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("World"))
        {
            currentSpeed = moveSpeed;
            boostText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        var move = 0.0f;
        var steer = 0.0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1.0f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1.0f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1.0f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1.0f;
        }

        var steerAmount = steer * steerSpeed * Time.deltaTime;
        var moveAmount = move * currentSpeed * Time.deltaTime;

        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}