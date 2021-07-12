using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{

    public UnityEvent<Vector2> MouseInput;
    public UnityEvent Shoot;
    public Camera camera;

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            
            var pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
            MouseInput.Invoke(camera.ScreenToWorldPoint(pos));

        }
        
        if(Input.GetButtonDown("Jump"))
        {
            Shoot.Invoke();
        }
    }
    
}
