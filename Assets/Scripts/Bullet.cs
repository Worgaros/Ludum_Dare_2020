using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    PolygonCollider2D bulletCollider;
    [SerializeField] GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        bulletCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemi"))
        {
            Camera.main.GetComponent<ScreenShakeBehavior>().TriggerShake(0.1f);
        }
        GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }
}
