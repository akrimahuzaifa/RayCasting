using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Rigidbody rb;
       
    public CharacterController controller;
    [SerializeField] float speed = 5f;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xHorizontalMovement = Input.GetAxis("Horizontal");
        float zVerticalMovement = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xHorizontalMovement + transform.forward * zVerticalMovement;

        controller.Move(move * speed * Time.deltaTime);

/*        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(new Vector3(horizontalMovement, 0, verticalMovement));*/

        //float yLimit = Mathf.Clamp(verticalMovement, -90, 90);
        //rb.velocity = new Vector3(horizontalMovement, rb.velocity.y, verticalMovement);

    }
}
