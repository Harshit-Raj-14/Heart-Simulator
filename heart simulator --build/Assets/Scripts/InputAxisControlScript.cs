using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputAxisControlScript : MonoBehaviour
{
    //zoom code
    private CinemachineFreeLook FLC = null;
    private CinemachineFreeLook.Orbit[] OriginalOrbits = new CinemachineFreeLook.Orbit[3];
    
    [Range(-8f,8f)] //it gets us a slider in unity inspector for zoomrange
    public float ZoomRange = 0f;
    public float MouseWheelSpeed = 20f;
    public float ZoomDampSpeed = 5f;
    public Slider SliderControl = null;

    
    private void Awake()
    {
        FLC = GetComponent<CinemachineFreeLook>();
        CinemachineCore.GetInputAxis = getAxisCustom;

        for(int i=0; i<3; i++) OriginalOrbits[i] = FLC.m_Orbits[i];   
    }

    private void Update()
    {
        ScaleOrbits();
    }

    float getAxisCustom(string Axis)
    {
        if(Axis.Equals("Horizontal"))
        {
            #if UNITY_EDITOR || UNITY_STANDALONE
            if(Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())   //when mouse is pressed axis control is given to Mouse Axes but at the same time not pressed over any interface element
                return Input.GetAxis("Mouse X");    
            #endif

            #if UNITY_IOS || UNITY_ANDROID
            if(Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject()) 
                return Input.touches[0].deltaPosition.x;   //for mobile devices
            #endif

            return Input.GetAxis("Horizontal");
        }

         if(Axis.Equals("Vertical"))
        {
            #if UNITY_EDITOR || UNITY_STANDALONE
            if(Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) 
                return Input.GetAxis("Mouse Y");
            #endif

            #if UNITY_IOS || UNITY_ANDROID
            if(Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject()) 
                return Input.touches[0].deltaPosition.y;   //for mobile devices
            #endif
            
            return Input.GetAxis("Vertical");
        }

        return 0f;
    }

    void ScaleOrbits()  //scale orbits in cinemachine by controlling the three rigs
    {
        if(Mathf.Abs(Input.mouseScrollDelta.y) == 0) return;
        ZoomRange -= Input.mouseScrollDelta.y * MouseWheelSpeed;
        ZoomRange = Mathf.Clamp(ZoomRange, -8f, 8f);

        for(int i=0; i<3; i++)
        {
            FLC.m_Orbits[i].m_Radius = Mathf.Lerp(FLC.m_Orbits[i].m_Radius, OriginalOrbits[i].m_Radius + ZoomRange, Time.deltaTime * ZoomDampSpeed);
        }
    }

    public void updteSlider()
    {
        ZoomRange = SliderControl.value;
        for(int i=0; i<3; i++)
        {
            FLC.m_Orbits[i].m_Radius = Mathf.Lerp(FLC.m_Orbits[i].m_Radius, OriginalOrbits[i].m_Radius + ZoomRange, Time.deltaTime * ZoomDampSpeed);
        }

    }
}
