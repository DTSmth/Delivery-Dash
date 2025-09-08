using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bang");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entered trigger");
    }
}
