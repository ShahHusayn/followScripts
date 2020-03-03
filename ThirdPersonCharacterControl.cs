using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float Speed;
    Animator anim;
    bool isWalking = false;
    Rigidbody playerRb;
    public GameObject player, target; 
    Quaternion lookRight = Quaternion.Euler(0f, 90f, 0f);
    Quaternion lookLeft = Quaternion.Euler(0f, -90f, 0f);
    Quaternion lookForward = Quaternion.Euler(0f, 0f, 0f);
    Quaternion lookBackward = Quaternion.Euler(0f, 180f, 0f);

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        PlayerMovement();
        PlayerRotation();
        Animating(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);       
    }


    void Animating(float h, float v)
    {
        isWalking = h != 0f || v != 0f;
        anim.SetBool("isWalking", isWalking);
    }


    void PlayerRotation()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            //player.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookRight, Time.deltaTime*5f);
            target.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookRight, Time.deltaTime * 5f);
        }
        if (Input.GetAxis("Horizontal") <0)
        {
            //player.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookLeft, Time.deltaTime * 5f);
            target.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookLeft, Time.deltaTime * 5f);
        }
        if (Input.GetAxis("Vertical") >0)
        {
            //player.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookForward, Time.deltaTime * 5f);
            target.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookForward, Time.deltaTime * 5f);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            //player.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookBackward, Time.deltaTime * 5f);
            target.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookBackward, Time.deltaTime * 5f);
        }
    }
}