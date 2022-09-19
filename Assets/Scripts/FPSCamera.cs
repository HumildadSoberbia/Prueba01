using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public Vector2 sensibility;
    private new Transform camera;
    public float velocidad = 1;
    public float salto = 1;
    private Rigidbody rigidbody;
            
        
    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Main Camera");
        Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Mouse Y");
        

        if (horizontal != 0) {
            transform.Rotate(Vector3.up * horizontal * sensibility);
        }

        if (vertical != 0) {
            //transform.Rotate(Vector3.left * vertical * sensibility);
            float angulo = (camera.localEulerAngles.x - vertical * sensibility.y + 360) % 360;
            if (angulo > 180) {angulo -= 360;}
            angulo = Mathf.Clamp(angulo, -80, 80);
            camera.localEulerAngles = Vector3.right * angulo;
        }
        
        var ejeX = Input.GetAxis("Horizontal"); // Estos son valores que varian entre -1 y 1
        var ejeZ = Input.GetAxis("Vertical"); // Estos son valores que varian entre -1 y 1
        
        // Mover el personaje, su posicion en el eje x, y en el eje z
        transform.Translate(new Vector3(ejeX, y:0, ejeZ) * (Time.deltaTime * velocidad));
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            rigidbody.AddForce(new Vector3(0,salto, 0), ForceMode.Impulse);
        }
    }
    
}
