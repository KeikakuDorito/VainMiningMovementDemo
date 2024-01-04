using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private Rigidbody rb;
    //public LayerMask layerMask;
    //float xInput;
    //float yInput;
    float movementSpeed = 5f;
    Vector3 input;
    Vector3 skewedInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }


    private void FixedUpdate()
    {
        movement();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        //look at mouse
        rotateToMouse();

        if (Input.GetKeyDown("space"))
        {
            Dash();
        }
    }

    void getInput()
    {
        input = new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal"));
    }

    void movement()
    {
        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

        skewedInput = matrix.MultiplyPoint3x4(input);

        rb.MovePosition(transform.position + skewedInput * movementSpeed * Time.deltaTime);
    }

    void rotateToMouse()
    {
        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            //transform.rotation = Quaternion.LookRotation(raycastHit.point.x, 0f, raycastHit.point.z);
            transform.LookAt(new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z));
            //Debug.Log(raycastHit.point);
        }
        //
        //var relative = mousePos - transform.position;

        //var rot = Quaternion.LookRotation(relative);

        //transform.rotation = rot;

        //Vector3 input = new Vector3 
    }

    void Dash()
    {
        rb.AddForce(skewedInput * 10f, ForceMode.Impulse);
        Debug.Log("kk");
    }
}
