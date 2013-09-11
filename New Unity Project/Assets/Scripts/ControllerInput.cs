using UnityEngine;
using System.Collections;

public abstract class ControllerInput : MonoBehaviour {

    public bool IsActive
    {
        get { return isActive; }
    }
    protected bool isActive = false;

    public bool IsPressed
    {
        get { return isPressed; }
    }
    protected bool isPressed = false;
}