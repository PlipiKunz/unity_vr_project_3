using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Grabbable : XRGrabInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        setNotCollidable();
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        setCollidable();
    }

    private string setCollidable() {
        gameObject.layer = 0;
        return "";
    }

    private string setNotCollidable()
    {
        gameObject.layer = 1;
        return "";
    }

}
