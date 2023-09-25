using System.Collections;
using System.Collections.Generic;
using TiltFive;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public GameObject gameObject1;
    public float speed = 1.0f;
    public float zoomSpeed = 1.0f;
    float zoomAmount = 1.0f;
    
    public void MoveCube(InputAction.CallbackContext context) {
        this.transform.Translate(context.ReadValue<Vector2>().x * Time.deltaTime * speed, 0, context.ReadValue<Vector2>().y * Time.deltaTime * speed);
    }

    
    void Update(){
        if(TiltFive.Wand.TryGetWandDevice(TiltFive.PlayerIndex.One,TiltFive.ControllerIndex.Right, out TiltFive.WandDevice wandDevice))
        {
            
            if (wandDevice.X.isPressed)
            {
                
                gameObject1.transform.Rotate(0,Time.deltaTime * speed,0);
            }
            if (wandDevice.B.isPressed)
            {
                
                gameObject1.transform.Rotate(0,-Time.deltaTime * speed,0);
                
                
            }
            if(wandDevice.One.isPressed){
                zoomAmount += zoomSpeed * Time.deltaTime;
                TiltFiveManager2.Instance.playerOneSettings.gameboardSettings.currentGameBoard.localScale = zoomAmount;
            }
             if(wandDevice.Two.isPressed){
                zoomAmount -= zoomSpeed * Time.deltaTime;
                if(zoomAmount <= 0) zoomAmount = 0.01f;
                TiltFiveManager2.Instance.playerOneSettings.gameboardSettings.currentGameBoard.localScale = zoomAmount;
            }
   
        
    }
}
}
 

