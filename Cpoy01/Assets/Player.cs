using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerSTATE
    {
        IDLE = 0,
        DOWN,
        UP,
        TURN,
        GROUND,
        JUMPUP,
        JUMPDOWN
    }
    public PlayerSTATE State;
    public GameObject Gargori;
   
    public float Speed;
    public float buffSpeed;
    public float RotateSpeed;
    
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case PlayerSTATE.IDLE:
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    
                    Gargori.transform.Translate(0, 0, Gargori.GetComponent<GargoriScripts>().Speed * Time.deltaTime);
                }
                else if(Input.GetKeyUp(KeyCode.Mouse0))
                {
                    Gargori.transform.position = transform.position;
                    State = PlayerSTATE.IDLE;
                }
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    State = PlayerSTATE.JUMPUP;
                }
                break;
            case PlayerSTATE.DOWN:
                transform.Translate(0, -Speed * Time.deltaTime, 0);
                if(transform.position.y <= dir.y-3)
                {
                    dir = transform.position;
                    State = PlayerSTATE.UP;
                }
                break;
            case PlayerSTATE.UP:
                transform.Translate(0, Speed * Time.deltaTime +buffSpeed, 0);
                if (transform.position.y >= dir.y +5)
                {
                    State = PlayerSTATE.TURN;
                }
                break;
            case PlayerSTATE.TURN:
                transform.Rotate(RotateSpeed * Time.deltaTime, 0, 0);
                if(transform.rotation.x < 0 && transform.rotation.x > -3)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    State = PlayerSTATE.GROUND;
                }
                break;
            case PlayerSTATE.GROUND:
                {
                    transform.Translate(0, -Speed * Time.deltaTime, 0);
                }
                break;
            case PlayerSTATE.JUMPUP:
                
                break;
            case PlayerSTATE.JUMPDOWN:
                break;

        }
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            transform.position = new Vector3(0, 0, 0);
            State = PlayerSTATE.IDLE;
        }
    }
}
