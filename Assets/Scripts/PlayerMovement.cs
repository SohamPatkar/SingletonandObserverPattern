using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private float speed = 10f;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        float getHorizontal = Input.GetAxis("Horizontal");
        float getVertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(getHorizontal * speed * Time.deltaTime, 0, getVertical * speed * Time.deltaTime));

    }
}
