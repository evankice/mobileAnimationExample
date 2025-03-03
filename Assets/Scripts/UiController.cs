using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ShowInventory()
    {
        anim.SetBool("showInventory",true);
    }

    public void HideInventory()
    {
        anim.SetBool("showInventory",false);
    }
}
