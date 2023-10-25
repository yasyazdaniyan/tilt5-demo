using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Information : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TMP_Text machineName;
    [SerializeField] TMP_Text machineInfo;

    [Header("Input Information")]
    [SerializeField] string machineNameString;
    [TextArea(3, 10)]
    [SerializeField] string machineInfoString;

    void Start()
    {
        machineName.text = machineNameString;
        machineInfo.text = machineInfoString;
    }
}
