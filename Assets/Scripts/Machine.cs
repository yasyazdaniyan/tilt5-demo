using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR;

public class Machine : MonoBehaviour
{
   [SerializeField] GameObject canvas;

    public void ToggleCanvas()
    {
        canvas.SetActive(!canvas.activeInHierarchy);
    }

    public bool GetIsActive()
    {
        return canvas.activeInHierarchy;
    }
}
