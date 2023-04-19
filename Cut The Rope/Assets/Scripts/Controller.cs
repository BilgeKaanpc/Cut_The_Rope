using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("target"))
        {
            _GameManager.MinusObject();
        }
        else if (collision.CompareTag("ball"))
        {
            _GameManager.MinusBall();
        }
    }
}
