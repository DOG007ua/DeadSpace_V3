using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float damage;
    float time = 0;
    float speed = 20;

    void Start()
    {
        
    }

    public void Initialize(float damage)
    {
        this.damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
        time += Time.deltaTime;
        if(time > 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            var unit = collision.transform.GetComponent<Unit>();
            unit.Damage(damage);
            Destroy(this.gameObject);
        }
    }
}
