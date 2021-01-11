using UnityEngine;

public abstract class PieceOfChest : MonoBehaviour
{
    [SerializeField] private string id;
    public string Id => id;
}