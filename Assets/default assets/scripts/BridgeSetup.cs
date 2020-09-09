using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSetup : MonoBehaviour
{
    public GameObject playerPlaceholder;
    public GameObject cabinBody;

    [Header("Crew Positions")]
    public GameObject crewHelmPlaceholder;
    public GameObject crewComsPlaceholder;
    public GameObject crewTactPlaceholder;

    public GameObject[] crewExtraPlaceholders;

    [Header("Screen Positions")]
    public GameObject shipAlert;
    public GameObject shipStats;
    public GameObject shipSpeed;

}
