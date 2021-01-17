using System;
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
        PrintGroundIsAvalible();
    }

    private void OnMouseUp()
    {
        Debug.Log(ServiceLocator.Instance.GetService<ICusor>().GetGround().gameObject.name);
        ServiceLocator.Instance.GetService<ICusor>().GetGround().AddPiece(ServiceLocator.Instance.GetService<ICusor>().GetPiece());
    }

    private void AddPiece(PieceOfChest pieceOfChest)
    {
        piece = pieceOfChest;
        piece.gameObject.transform.parent = transform;
        piece.transform.localPosition = Vector2.zero;
    }

    private void OnMouseOver()
    {
        //puede darnos el cuadro que podemos dejar el coso
        if (isEmpty())
        {
            ServiceLocator.Instance.GetService<ICusor>().SaveGroud(this);
        }
    }

    private void OnMouseDrag()
    {
        //Aqui lo que vamos a hacer es mover el gameobject junto con la posicion del mouse
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        if (!isEmpty())
        {
            piece.gameObject.transform.position = worldPosition;
        }
    }

    public void PrintGroundIsAvalible()
    {
        if (gameObject.TryGetComponent<Ground>(out var ground))
        {
            if (!ground.isEmpty())
            {
                var piece = ground.GetPiece();
                ServiceLocator.Instance.GetService<ICusor>().SavePiece(piece);
                this.piece = null;
                foreach (PositionInTable posicion in piece.ListPosicionInTable(ground, viewMap, Map))
                {
                    if (viewMap[posicion.X, posicion.Y].TryGetComponent<SpriteRenderer>(out var spriteRender))
                    {
                        spriteRender.color = Color.green;
                    }
                }
            }
        }
    }
}