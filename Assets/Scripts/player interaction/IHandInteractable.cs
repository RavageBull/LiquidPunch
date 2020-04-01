using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandInteractable
{

    void OnHandInteractionGainFocus(HandInteractionScript h);
    void OnHandInteractionLoseFocus(HandInteractionScript h);
    void OnHandInteractTriggerPull(HandInteractionScript h);

}
