using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogDensity : MonoBehaviour
{
    [SerializeField] float normalFogEnd;
    float upgradedFogEnd;
    // Start is called before the first frame update
    void Start()
    {
        upgradedFogEnd = normalFogEnd + GameManager.Instance.clarityMultiplier;
        RenderSettings.fogEndDistance = upgradedFogEnd;
    }

}
