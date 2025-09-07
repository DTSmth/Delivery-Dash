using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

        float moveAmount = move * moveSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Rotate(0f, 0f, steerAmount);
        transform.Translate(0f, moveAmount, 0f);
    }
}
