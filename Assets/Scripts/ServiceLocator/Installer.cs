using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Installer : MonoBehaviour, IInstallerServiceLocator, IDices, IDebugView
{
    [SerializeField] private TextMeshProUGUI textForTurn;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI TextOfDebug;
    private void Awake()
    {
        var cursor = new Cursor();
        ServiceLocator.Instance.RegisterService<ICusor>(cursor);
        var turnSystem = new TurnSystem(this);
        ServiceLocator.Instance.RegisterService<ITurnSystem>(turnSystem);
        var serviceOfDies = new Dice(6, this);
        ServiceLocator.Instance.RegisterService<IServiceOfDies>(serviceOfDies);
        var serviceOfDebug = new ServiceOfDebug(this);
        ServiceLocator.Instance.RegisterService<IServiceOfDebug>(serviceOfDebug);

        button.onClick.AddListener(() => ThrowDice());
    }

    private void ThrowDice()
    {
        ServiceLocator.Instance.GetService<IServiceOfDies>().ThrowDice();
        string value = ServiceLocator.Instance.GetService<IServiceOfDies>().GetIdPiece();
        ServiceLocator.Instance.GetService<IServiceOfDebug>().PrintDebug($"La pieza que debes mover es la: {value}");
    }

    public void WhriteTextInTurn(string text)
    {
        textForTurn.text = text;
    }

    public int RandomFront(int v, int faces)
    {
        var randomNumber = Random.Range(v, faces);
        WhriteTextInDebug(randomNumber + "");
        return randomNumber;
    }

    public void DebugLocal(object numberResult)
    {
        WhriteTextInDebug(numberResult + "");
    }

    public void WhriteTextInDebug(string text)
    {
        TextOfDebug.text = text;
    }
}