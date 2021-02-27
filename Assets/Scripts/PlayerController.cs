//TODO
/*
çatışma mekanikleri
*/
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float  speed;    
    [SerializeField] private float  lookSens;
    
    private PlayerMotor motor;
    void Awake()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        CalculateVelocity();
        CameraMovement();        
    }
    void CalculateVelocity()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMove;
        Vector3 movVertical = transform.forward * yMove;
        
        Vector3 velocity = (movHorizontal+movVertical).normalized * speed;

        motor.Move(velocity);
    }
    void CameraMovement()
    {
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotatiton = new Vector3(0, yRot, 0)* lookSens;

        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(xRot, 0, 0)* lookSens;
        
        motor.Rotate(rotatiton, camRotation);
    }
}
