using System.Collections;
using TMPro;
using UnityEngine;

public class ControladorDeLogsVisuales : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI logVisual;
    
    public void AgregarLogvisual(string log)
    {
        logVisual.text += "\n" + log;
    }
}
