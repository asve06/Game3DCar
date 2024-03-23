using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f; 

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
