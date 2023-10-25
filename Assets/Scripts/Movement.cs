using System.Collections;
using System.Collections.Generic;
using TiltFive;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;

    public float moveSpeed = 1.0f;
    public float rotateSpeed = 1.0f;
    public float zoomSpeed = 1.0f;
    float zoomAmount = 1.0f;
    private Animator gameObjectAnimator;
    bool isWalking;
  /*  public void MoveCube(InputAction.CallbackContext context) {
        this.transform.Translate(context.ReadValue<Vector2>().x * Time.deltaTime * speed, 0, context.ReadValue<Vector2>().y * Time.deltaTime * speed);
    }
*/

    void Start(){
        gameObjectAnimator = gameObject2.GetComponent<Animator>();
    }
    
    void Update(){
        if(TiltFive.Wand.TryGetWandDevice(TiltFive.PlayerIndex.One,TiltFive.ControllerIndex.Right, out TiltFive.WandDevice wandDevice))
        {
            Vector2 InputMovement = wandDevice.Stick.ReadValue();
            Vector3 MovementDir = new Vector3(InputMovement.x,0,InputMovement.y);
            MovementDir = MovementDir.normalized;
            gameObject2.transform.position += MovementDir * Time.deltaTime * moveSpeed;
            TiltFiveManager2.Instance.playerOneSettings.gameboardSettings.currentGameBoard.position += MovementDir * Time.deltaTime * moveSpeed;

            isWalking = MovementDir.magnitude >= new Vector3(0.01f,0.01f,0.01f).magnitude;

            gameObjectAnimator.SetBool("isWalking",isWalking);
            
            if (wandDevice.X.isPressed)
            {
                //gameObject1.transform.Rotate(0,Time.deltaTime * rotateSpeed,0);
                TiltFiveManager2.Instance.playerOneSettings.gameboardSettings.currentGameBoard.rotation *= Quaternion.Euler(0, Time.deltaTime * rotateSpeed, 0);
            }
            if (wandDevice.B.isPressed)
            {
                //gameObject1.transform.Rotate(0,-Time.deltaTime * rotateSpeed,0);
                TiltFiveManager2.Instance.playerOneSettings.gameboardSettings.currentGameBoard.rotation *= Quaternion.Euler(0, -Time.deltaTime * rotateSpeed, 0);


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
 

