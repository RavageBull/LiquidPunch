using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandInteractable
{
    bool TargetedByOther(HandInteractionScript h);
    void OnHandInteractionGainFocus(HandInteractionScript h);
    void OnHandInteractionLoseFocus(HandInteractionScript h);
    void OnHandInteractTriggerDown(HandInteractionScript h);
    void OnHandInteractTrigger(HandInteractionScript h);
    void OnHandInteractTriggerUp(HandInteractionScript h);

}
