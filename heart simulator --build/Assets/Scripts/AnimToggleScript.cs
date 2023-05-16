using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimToggleScript : MonoBehaviour
{
    public string AnimValue = string.Empty;
    public float MaxValue = 1.0f;
    private float DestValue = 0f;
    private float CurrentValue = 0f;
    public float Speed = 2f;
    private Animator ThisAnimator = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("escape")) Application.Quit();

CurrentValue = Mathf.Lerp(CurrentValue, DestValue, Time.deltaTime * Speed);
       ThisAnimator.SetFloat(AnimValue, CurrentValue);

       //Debug lines
       if(Input.GetKeyDown(KeyCode.Space))
       {
        ToggleValue();
       }
    }

    private void Awake()
    {
        ThisAnimator = GetComponent<Animator>();
        DestValue = CurrentValue = 0f;
    }

    public void ToggleValue()
    {
        DestValue = (DestValue < MaxValue) ? MaxValue : 0f; //if destvalue is the middle state, then this statement helps to reach form one extreme 2 to another extreme 0
    }
}

/*This code has been written to smoothen the animation when heart stops and starts
DestVlue - destination value
Cotraction and breathing can be considered shm and destvalue their mean(at 1), extrme(0,2)
*/
