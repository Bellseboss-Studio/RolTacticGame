using UnityEngine;

public abstract class Ground : MonoBehaviour
{
    [SerializeField] private string id;
    private PieceOfChest piece;
    private Ground[,] viewMap;
    private Map map;

    public string Id => id;

    public void AddPieceOfChest(PieceOfChest piece, Ground[,] viewMap, Map map)
    {
        this.piece = piece;
        this.viewMap = viewMap;
        this.map = map;
    }

    public PieceOfChest GetPiece()
    {
        if (isEmpty())
        {
            throw new GetPieceOfChessNotExist("The piece in this ground not exist");
        }
        return piece;
    }

    public bool isEmpty() => piece == null;

    private void OnMouseDown()
    {
            //comprobamos que tenga el componente de Ground
            if (gameObject.TryGetComponent<Ground>(out var ground))
            {
                if (!ground.isEmpty())
                {
                    var piece = ground.GetPiece();
                    foreach (PositionInTable posicion in piece.ListPosicionInTable(ground, viewMap, map))
                    {
                        if (viewMap[posicion.X, posicion.Y].TryGetComponent<SpriteRenderer>(out var spriteRender))
                        {
                            spriteRender.color = Color.green;
                        }
                    }
                    Debug.Log("La pieza es: " + piece.Id + " con nombre del gameObect de :" + piece.gameObject.name);
                }
            }
        
    }
}