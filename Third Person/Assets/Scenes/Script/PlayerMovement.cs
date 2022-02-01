using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 6.0f;
    private float rotSpeed = 360.0f;
   [SerializeField]
    public CharacterController cc;

    void Start()
    {
        

       // cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //transform.Translate(movement * Time.deltaTime * speed);
        
        movement = transform.TransformDirection(movement);
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        cc.Move(movement * Time.deltaTime * speed);

        Vector3 rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        transform.Rotate(rotation * Time.deltaTime * rotSpeed);
    }
}
