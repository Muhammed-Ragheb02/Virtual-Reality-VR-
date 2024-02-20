using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Button : XRBaseInteractable
{
    [SerializeField] private device device;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        ClickedAnim();
    }
    private void ClickedAnim()
    {
        if(device.OnOffButton())
            transform.localScale = new Vector3( transform.localScale.x,.7f, transform.localScale.z);
        else
            transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
    }
}
