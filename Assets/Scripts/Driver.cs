using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float regularSpeed = 5f;
    bool hasBoost = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost") && !hasBoost)
        {
            hasBoost = true;
            currentSpeed = boostSpeed;
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = regularSpeed;
        hasBoost = false;
    }

    // Update is called once per frame
    void Update()
    {

        float move = 0f;
        float steer = 0f;
        
        if (Keyboard.current.wKey.isPressed) {
            move = 1f;
        } else if (Keyboard.current.sKey.isPressed) {
            move = -1f;
        }

        if (Keyboard.current.aKey.isPressed) {
            steer = 1f;
        } else if (Keyboard.current.dKey.isPressed) {
            steer = -1f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Rotate(0f, 0f, steerAmount);
        transform.Translate(0f, moveAmount, 0f);
    }
}
