using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    Rigidbody2D rb;
    public float velX;
    public float velY;
    Vector3 moveDirection;
    public int player;
    public int bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 test = new Vector3(10f, 0, 0);

        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        moveDirection.z = 0;
        moveDirection.Normalize();

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag != "Player") Destroy(gameObject);
        Physics2D.IgnoreLayerCollision(player, bullet, true);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + moveDirection * 5 * Time.deltaTime;
    }
}
