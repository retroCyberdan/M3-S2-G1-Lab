using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //FISICA -> nel FixedUpdate
    //INPUT -> nell'Update
    //
    //
    //
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    Rigidbody2D _rb;
    private bool isJumping = false;
    public int playerNumber;
    private string playerHorizontal;
    private string playerJump;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        SetPlayer(playerNumber);
        playerHorizontal = $"P{playerNumber}Horizontal";
        playerJump = $"P{playerNumber}Jump";
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown(playerJump))
        {
            isJumping = true;
            Vector2 velocity = _rb.velocity;
            velocity.y = _jumpForce;
            _rb.velocity = velocity;

            //utilizzo la property "AddForce()":
            //_rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if (Input.GetButtonUp(playerJump))
        {
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        float hor = Input.GetAxis(playerHorizontal);

        //esegue le azioni solo se cambia il valore di "hor"
        if (hor != 0)
        {
                //inizializzo un vector 2 con coordinate "hor" e 0, quindi lo normalizzo e uso la proprietà "MovePosition" per muoverlo:
                //Vector2 direction = new Vector2(hor, 0);
                //direction.Normalize();
                //_rb.MovePosition(_rb.position + direction * (_speed * Time.deltaTime));

                //qui invece uso la "velocity" del Rigidbody2Dper il movimento:
                _rb.velocity = new Vector2(hor * _speed, _rb.velocity.y);// <- come "y" gli passo il suo stesso valore
        }
     }

    public void SetPlayer (int playerNumber)
    {
        if (playerNumber < 0 || playerNumber > 2)
        {
            Debug.Log($"Devi scegliere tra Player 1 o Player 2!");
        }
    }
}
