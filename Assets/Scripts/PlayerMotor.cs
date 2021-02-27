//TODO
/*
yukarı ve aşağıya bakmada sınırlama(Mathf.Clamp?)
raycasting ile crosair ve silah sistemi(Raycasting)
kamera açısına göre silahın açı alması(Raycasting)
*/

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    //Veriables
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camRotation = Vector3.zero;


    //Referances
    [SerializeField] private Camera cam;
    public Transform orientation;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Cursor.lockState= CursorLockMode.Locked;
    }


    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if (velocity !=Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {       
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.Rotate(-camRotation);
        }
        
        
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    public void Rotate(Vector3 _rotation, Vector3 _camRotation)
    {
        rotation = _rotation;
        camRotation =_camRotation;       
    }
    

}
