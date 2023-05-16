using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencePlayerScript : MonoBehaviour
{
    public GameObject Dialogue;
    // public GameObject Toggle;


    private void Awake()
    {
        Dialogue.SetActive(false);
    }

    public void ShowInfo()
    {
        if(Dialogue.activeInHierarchy ==true) Dialogue.SetActive(false);
        else Dialogue.SetActive(true);
    }
       
}  

//This script was written to play the dialogue boxes sequentially when pressed 
/*    
    private int Index = 0;

    private void Awake()
    {
        RestItems();
    }

    public void RestItems(){
        if(transform.childCount <=0) return;

        Index=0;

        for(int i=0;i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(Index).gameObject.SetActive(true);

    }

    public void NextItem()
    {
        if(transform.childCount <=0) return;

        Index = Mathf.RoundToInt(Mathf.Repeat(Index+1, transform.childCount));

        for(int i=0;i<transform.childCount;i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(Index).gameObject.SetActive(true);
        
    }
}
*/