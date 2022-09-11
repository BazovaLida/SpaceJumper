using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumping_speed = 2.0f;
    public float gravity = 0.0f;

    public GameObject staying_player;
    public GameObject walking_player;
    public GameObject jumping_player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        float walking = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float jumping = (Input.GetAxis("Vertical") * jumping_speed  + gravity)  * Time.deltaTime;
        
        if (walking > 0) 
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (walking < 0)
        {
            // walking = - walking;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        transform.Translate(new Vector3(walking, jumping, 0), Space.World);


        if (walking != 0 && jumping == 0) 
        {
            player_state("walk");
        } 
        else if (jumping != 0) 
        {
            player_state("jump");
        } 
        else
        {
            player_state("stay");
        }

    }

    void player_state (string state)
    {
        switch (state)
        {
            case "walk":
                staying_player.SetActive(false);
                walking_player.SetActive(true);
                jumping_player.SetActive(false);
                break;
            case "jump":
                staying_player.SetActive(false);
                walking_player.SetActive(false);
                jumping_player.SetActive(true);
                break;
            default:
                staying_player.SetActive(true);
                walking_player.SetActive(false);
                jumping_player.SetActive(false);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision");
        if(other.gameObject.tag == "Platform"){
            transform.Translate(0, 0, 0);
            player_state("stay");
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collision");
        if(other.gameObject.tag == "Platform"){
            
        }
    }
}
