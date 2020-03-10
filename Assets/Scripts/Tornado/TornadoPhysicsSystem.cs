using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Just throws objects around the tornado and gradually pulls them up into the air.
/// </summary>
public class TornadoPhysicsSystem : MonoBehaviour
{
    
    public List<TornadoEffected> tornadoEffecteds;

    public List<TornadoEffected> GetTornadoEffecteds()
    {
        return FindObjectsOfType<TornadoEffected>().ToList();
    }
    public Vector3 CalculateForceAroundAxis(TornadoEffected t)
    {
        return t.transform.position;
    }

}
