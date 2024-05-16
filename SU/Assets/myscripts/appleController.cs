using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class appleController : MonoBehaviour
{
    [SerializeField] Text scoreValueText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int scoreValue = int.Parse(scoreValueText.text);
            scoreValue += 1;
            scoreValueText.text = scoreValue.ToString();
            Destroy(gameObject);
        }
    }
}
