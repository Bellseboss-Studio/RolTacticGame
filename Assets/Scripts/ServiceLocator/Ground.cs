using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ground : MonoBehaviour
{
    [SerializeField] private string id;
    private PieceOfChest piece;
    [SerializeField] private Color colorOriginal;

    public string Id => id;

    public void AddPieceOfChest(PieceOfChest piece)
    {
        this.piece = piece;
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

    public void ColocarColorOriginalAlGround()
    {
        var mapp = ServiceLocator.Instance.GetService<ICusor>().GetMap();
        var viewMap = ServiceLocator.Instance.GetService<ICusor>().GetViewMap();
        for (var X = 0; X < mapp.Heigth;X++)
        {
            for (var Y = 0; Y < mapp.Width;Y++)
            {
                if (viewMap[X, Y].TryGetComponent<SpriteRenderer>(out var spriteRender))
                {
                    spriteRender.color = viewMap[X, Y].colorOriginal;
                }
            }
        }
    }

    public void PrintGroundIsAvalible()
    {
        if (gameObject.TryGetComponent<Ground>(out var ground))
        {
            if (!ground.isEmpty())
            {
                if (ServiceLocator.Instance.GetService<ICusor>().IsInMoved())
                {
                    if (!TheMovivedIsLegal(ground))
                    {
                        ServiceLocator.Instance.GetService<ICusor>().CleanPiece();
                        ServiceLocator.Instance.GetService<ICusor>().CleanGround();
                        return;
                    }
                    Destroy(ground.GetPiece().gameObject);
                    ground.piece = ServiceLocator.Instance.GetService<ICusor>().GetPiece();
                    ground.piece.transform.SetParent(ground.transform);
                    ground.piece.transform.localPosition = Vector2.zero;
                    ServiceLocator.Instance.GetService<ICusor>().CleanPiece();
                    ServiceLocator.Instance.GetService<ICusor>().CleanGround();
                    ColocarColorOriginalAlGround();
                    return;
                }
                
                var actualyPiece = ground.GetPiece();
                ServiceLocator.Instance.GetService<ICusor>().SavePiece(actualyPiece);
                ground.piece = null;
                var viewMap = ServiceLocator.Instance.GetService<ICusor>().GetViewMap();
                foreach (PositionInTable posicion in actualyPiece.ListPosicionInTable(ground))
                {
                    if (viewMap[posicion.X, posicion.Y].TryGetComponent<SpriteRenderer>(out var spriteRender))
                    {
                        spriteRender.color = Color.green;
                    }
                }
                ServiceLocator.Instance.GetService<ICusor>().SaveGroud(ground);
                return;
            }

            if (!ServiceLocator.Instance.GetService<ICusor>().IsInMoved()) {
                return;
            }

            var piece = ServiceLocator.Instance.GetService<ICusor>().GetPiece();
            var groundSaved = ServiceLocator.Instance.GetService<ICusor>().GetGround();
            
            if (TheMovivedIsLegal(ground))
            {
                ground.piece = piece;
                ground.piece.transform.SetParent(ground.transform);
                ground.piece.transform.localPosition = Vector2.zero;
            }
            else
            {
                groundSaved.piece = piece;
                groundSaved.piece.transform.SetParent(groundSaved.transform);
                groundSaved.piece.transform.localPosition = Vector2.zero;
                groundSaved.piece.Restart();
            }
            ServiceLocator.Instance.GetService<ICusor>().CleanPiece();
            ServiceLocator.Instance.GetService<ICusor>().CleanGround();
            ColocarColorOriginalAlGround();
        }
    }

    private bool TheMovivedIsLegal(Ground ground)
    {
        var viewMap = ServiceLocator.Instance.GetService<ICusor>().GetViewMap();
        var saveGround = ServiceLocator.Instance.GetService<ICusor>().GetGround();
        var pieceSaved = ServiceLocator.Instance.GetService<ICusor>().GetPiece();
        foreach (PositionInTable posicion in pieceSaved.ListPosicionInTable(saveGround))
        {
            if (viewMap[posicion.X, posicion.Y].name == ground.name)
            {
                return true;
            }
        }
        return false;
    }
}