using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float upForce = 700f;
    Rigidbody _rigidbody;

    bool _isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (_isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddRelativeForce(Vector3.up * upForce);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Grounded")
        {
            _isGrounded = true;
            Debug.Log("yes");
        }
        
    }
}
