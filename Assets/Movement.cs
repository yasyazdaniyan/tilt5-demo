using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public GameObject gameObject1;
    public float speed = 1.0f;
    public void MoveCube(InputAction.CallbackContext context) {
        this.transform.Translate(context.ReadValue<Vector2>().x * Time.deltaTime * speed, 0, context.ReadValue<Vector2>().y * Time.deltaTime * speed);
    }

    public void RotateCube(InputAction.CallbackContext context) {
        this.transform.Rotate(0,context.ReadValue<Vector2>().x * Time.deltaTime * speed,0);
    }
    void Update(){
        if(TiltFive.Wand.TryGetWandDevice(TiltFive.PlayerIndex.One,TiltFive.ControllerIndex.Right, out TiltFive.WandDevice wandDevice))
        {
            Debug.Log("Hi");
            if (wandDevice.One.isPressed)
            {
                Debug.Log("Slay detected");
                gameObject1.transform.Rotate(0,Time.deltaTime * speed,0);
            }
            if (wandDevice.Two.isPressed)
            {
                Debug.Log("Slay detected");
                gameObject1.transform.Rotate(0,-Time.deltaTime * speed,0);
            }
        }
    }
}
