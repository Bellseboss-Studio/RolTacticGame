using UnityEngine;

public class GroundFactory : IGroundFactory
{
    private readonly GroundConfiguration groundConfiguration;

    public GroundFactory(GroundConfiguration groundConfiguration)
    {
        this.groundConfiguration = groundConfiguration;
    }

    public Ground Create(string id)
    {
        var prefab = groundConfiguration.GetGroundPrefabById(id);

        return Object.Instantiate(prefab);
    }
}

public class PieceFactory
{
    private readonly PieceConfiguration pieceConfiguration;

    public PieceFactory(PieceConfiguration pieceConfiguration)
    {
        this.pieceConfiguration = pieceConfiguration;
    }

    public PieceOfChest Create(string id)
    {
        var prefab = pieceConfiguration.GetPiecePrefabById(id);

        return Object.Instantiate(prefab);
    }
}