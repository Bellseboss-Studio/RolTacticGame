using UnityEngine;

public abstract class Ground : MonoBehaviour
{
    [SerializeField] private string id;
    private PieceOfChest piece;
    private Ground[,] viewMap;

    public string Id => id;

    public Map Map { get; private set; }

    public void AddPieceOfChest(PieceOfChest piece, Ground[,] viewMap, Map map)
    {
        this.piece = piece;
        this.viewMap = viewMap;
        this.Map = map;
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
        /*if (gameObject.TryGetComponent<Ground>(out var ground))
        {
            if (!ground.isEmpty())
            {
                var piece = ground.GetPiece();
                foreach (PositionInTable posicion in piece.ListPosicionInTable(ground, viewMap, Map))
                {
                    if (viewMap[posicion.X, posicion.Y].TryGetComponent<SpriteRenderer>(out var spriteRender))
                    {
                        spriteRender.color = Color.green;
                    }
                }
            }
        }*/
        
    }
}