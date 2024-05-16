using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class playerController : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity;
    [SerializeField] float speed;
    [SerializeField] float jumppower;
    [SerializeField] GameObject winPanel, losePanel;
    soundController soundController;


    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        soundController = GetComponent<soundController>();
    }

    void Update()
    {
        

        velocity = new Vector3(Input.GetAxis("Horizontal"),0f);
        transform.position += speed * velocity * Time.deltaTime;

        if ((velocity.x == 0) && Mathf.Approximately(rgb.velocity.y, 0))
        {
            soundController.playRunSound();
        }
      



        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rgb.velocity.y, 0))
        {
            rgb.AddForce(Vector3.up * jumppower, ForceMode2D.Impulse);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(Waiter(true));
        }
    }
    public void player_die()
    {
        
        rgb.constraints = RigidbodyConstraints2D.FreezeRotation;
        enabled = false;
        StartCoroutine(Waiter(false));
        
    }
    IEnumerator Waiter(bool state)
    {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 0;
        if (state == true)
        {
            winPanel.SetActive(true);
        }
        else
        {
            losePanel.SetActive(true);
        }
        
    }

}
