using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorManager : MonoBehaviour
{
    public static EditorManager instance;

    GameControls inputAction;

  
    public Camera mainCam;
    public Camera editorCam;

    public bool editorMode = false;
    public bool instantiated = false;

   

    Vector3 mousePos;

   


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Editor.EnableEditor.performed += cntxt => SwitchCamera();

        mainCam.enabled = true;
        editorCam.enabled = false;
      
    }

    private void SwitchCamera()
    {
        mainCam.enabled = !mainCam.enabled;
        editorCam.enabled = !editorCam.enabled;

    }

    
    void Update()
    {
        if (mainCam.enabled == false && editorCam.enabled == true)
        {
            editorMode = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            editorMode = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (instantiated)
        {
            mousePos = Mouse.current.position.ReadValue();

            mousePos = new Vector3(mousePos.x, mousePos.y, 2.8f);
      
        }
    }
}
