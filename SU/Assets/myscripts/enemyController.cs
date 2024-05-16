using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public int healt = 2;
    int instantHealt;
    [SerializeField] GameObject effect;
    float counter=0f;
    // Start is called before the first frame update
    void Start()
    {
        instantHealt = healt;
    }
    
    private void FixedUpdate()
    {
        counter += 0.01f;
        if (counter >= 1.21f)
        {
            counter = -1.2f;
        }
        if (counter>=0)
        {
            transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.01f);
        }
        else
        {
            transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.01f);
        }
    }
    public void TakeDamage(int damage)
    {
        instantHealt -= damage;
        if (instantHealt <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
