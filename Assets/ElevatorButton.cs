using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ElevatorButton : XRBaseInteractable
{
    public int floor = 1;
    public CharacterController cc;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        MovePlayer(floor);
    }


    private void MovePlayer(int i)
    {
        cc.enabled = false;
        cc.transform.position = new Vector3(-6, 1, 0);
        cc.enabled = true;
    }

}
