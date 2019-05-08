using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D PlayerBody;
    public Rigidbody2D bullet;
    public float speed = 100;
    public float jumpModifier = 10;
    private bool rolling = false;
    private bool shooting = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rolling = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {

            shooting = true;
        }
        
    }

    void dodgeRoll(Vector2 movement)
    {
        PlayerBody.AddForce(movement*jumpModifier);
        rolling = false;
    }

    void handleMovement(Vector2 movement)
    {
        PlayerBody.AddForce(movement);
    }

    void shootBullet(Vector2 movement)
    {
        Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector2(0, 1))) as Rigidbody2D;


        shooting = false;
 
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        handleMovement(movement*speed);

        if(rolling) dodgeRoll(movement*speed);
        if (shooting) shootBullet(movement * speed);


    }
}
