using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] Camera Cam;
    Vector2 MousePosition;
    Vector2 direction;
    [SerializeField]float speed;
  

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(direction.x * speed* Time.fixedDeltaTime, direction.y * speed* Time.fixedDeltaTime);
        Vector2 lookDirection = MousePosition - body.position;
        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x)*Mathf.Rad2Deg;
        body.rotation = angle;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical")*speed);
        MousePosition = Cam.ScreenToWorldPoint(Input.mousePosition);
       
    }
   
   
}
