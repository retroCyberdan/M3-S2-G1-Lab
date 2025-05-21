using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    Rigidbody2D _rb;
    private bool isJumping = false;
    //private float jumpTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            //isJumping = true;
            ////jumpTimer += Time.deltaTime;
            //Vector2 velocity = _rb.velocity;
            //velocity.y = 12;
            //_rb.velocity = velocity;

            _rb.AddForce(Vector2.up * 12, ForceMode2D.Impulse);
        }
        else if (Input.GetButtonUp("Jump")) // <- true nel frame in cui rilasciamo [SPACE]
        {
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");

        if (hor != 0)
        {
            Vector2 direction = new Vector2(hor, 0);

            direction.Normalize();

            _rb.MovePosition(_rb.position + direction * (_speed * Time.deltaTime));
        }
    }
}
