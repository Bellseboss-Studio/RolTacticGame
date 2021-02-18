public interface ICusor
{
    void SaveGroud(Ground ground);
    Ground GetGround();
    void SavePiece(PieceOfChest piece);

    void CleanPiece();

    void CleanGround();
    PieceOfChest GetPiece();

    void SaveMap(Map map);

    Map GetMap();

    void SaveViewMap(Ground[,] viewMap);

    Ground[,] GetViewMap();

    bool IsInMoved();
}