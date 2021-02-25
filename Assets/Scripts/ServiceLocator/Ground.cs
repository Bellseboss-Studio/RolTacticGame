using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ground : MonoBehaviour, IGroundView
{
    [SerializeField] private string id;
    [SerializeField] private Color colorOriginal;
    private GroundLogic logic;

    public string Id => id;

    private void Awake()
    {
        logic = new GroundLogic(this);
    }

    private void OnMouseDown()
    {
        PrintGroundIsAvalible();
    }

    public void PrintGroundIsAvalible()
    {
        try
        {
            if (gameObject.TryGetComponent<Ground>(out var ground))
            {

                logic.PrintGroundIsAcalible(ground);
            }
        }
        catch (PieceInMovedIsIlegal e)
        {
            ServiceLocator.Instance.GetService<IServiceOfDebug>().PrintDebug($"Error: {e.Message}");
        }
        catch (IsNotAvalibleForThrowDice a)
        {
            ServiceLocator.Instance.GetService<IServiceOfDebug>().PrintDebug($"Error: {a.Message}");
        }
    }

    public void AddPieceOfChest(PieceOfChest pieceSaved)
    {
        logic.AddPieceOfChest(pieceSaved);
    }

    public void SetPiece(PieceOfChest pieceOfChest)
    {
        logic.Piece = pieceOfChest;
    }

    public PieceOfChest GetPiece()
    {
        return logic.GetPiece();
    }

    public bool isEmpty()
    {
        return logic.isEmpty();
    }

    public void ChangedColor(Ground ground)
    {
        if (ground.TryGetComponent<SpriteRenderer>(out var spriteRender))
        {
            spriteRender.color = ground.colorOriginal;
        }
    }

    public void ChangedColorToMove(Ground ground)
    {
        if (ground.TryGetComponent<SpriteRenderer>(out var spriteRender))
        {
            spriteRender.color = Color.green;
        }
    }

    public void DestroyObject(GameObject go)
    {
        Destroy(go);
    }

    public void ChangedLocalPositionToZero(PieceOfChest pieceOfChest)
    {
        pieceOfChest.transform.localPosition = Vector2.zero;
    }
}