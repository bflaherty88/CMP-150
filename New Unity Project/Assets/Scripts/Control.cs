using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {

    public string Name = "Control";
	private List<ControllerInput> inputs = new List<ControllerInput>();
    public bool IsActive
    {
        get {return isActive;}
    }
    private bool isActive = false;

    public bool IsPressed
    {
        get { return isPressed; }
    }
    private bool isPressed = false;

	void Start () {

        foreach (var input in gameObject.GetComponents<ControllerInput>())
        {
            if (inputs.Contains(input)) continue;

            inputs.Add(input);
        }
	}
	
	
	void Update () {
        isActive = false;
        foreach (var input in inputs)
        {
            if (input.IsActive)
            {
                isActive = true;
                break;
            }
        }

        isPressed = false;
        foreach (var input in inputs)
        {
            if (input.IsPressed)
            {
                isPressed = true;
                break;
            }
        }
	}
}
