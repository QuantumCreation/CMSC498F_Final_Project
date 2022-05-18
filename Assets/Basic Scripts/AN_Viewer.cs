using UnityEngine;

public class AN_Viewer : MonoBehaviour
{
    [TextArea]
    public string Description = "use it on empty obj with Camera as children. WASDQE - walk, RT - rotation, Shift - run";
    public float Walk = 1f, Run = 6f, RotateSpeed = 10f;
    public int Sensitivity = 100;
    public bool HideCursor = false;

    Vector3 Move;
    Transform Cam;
    float xmouse, ymouse, yRotation, Speed, upaxe, rotate_on_key;

    void Start()
    {
        Cam = transform.GetChild(0).transform;

        if (HideCursor)
        {
            Cursor.lockState = CursorLockMode.Locked; // freeze cursor on screen centre
            Cursor.visible = false; // invisible cursor
        }
    }

    void Update() // camera rotation
    {
        //axis
        xmouse = Input.GetAxis("Mouse X") * Time.deltaTime * Sensitivity;
        ymouse = Input.GetAxis("Mouse Y") * Time.deltaTime * Sensitivity;

        // result rotation
        transform.Rotate(Vector3.up * (xmouse + rotate_on_key));
        yRotation -= ymouse;
        yRotation = Mathf.Clamp(yRotation, -85f, 60f);
        Cam.localRotation = Quaternion.Euler(yRotation, 0, 0);

        // walk/run
        if (Input.GetKey(KeyCode.LeftShift)) Speed = Run;
        else Speed = Walk;

        // result moving
        Move = Cam.TransformDirection(Vector3.forward) * Speed * Input.GetAxis("Vertical") +
            Cam.TransformDirection(Vector3.right) * Speed * Input.GetAxis("Horizontal") +
            Cam.TransformDirection(Vector3.up) * upaxe;
        Move *= Time.deltaTime;
        transform.position += Move;
    }
}
