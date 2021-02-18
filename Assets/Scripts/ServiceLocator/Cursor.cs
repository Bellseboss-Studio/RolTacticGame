public class Cursor : ICusor
{
    private Ground ground;
    private PieceOfChest piece;
    private Map map;
    private Ground[,] viewMap;

    public void CleanPiece()
    {
        piece = null;
    }
    public void CleanGround()
    {
        ground = null;
    }
    public Ground GetGround()
    {
        return ground;
    }

    public Map GetMap()
    {
        return map;
    }

    public PieceOfChest GetPiece()
    {
        return piece;
    }

    public Ground[,] GetViewMap()
    {
        return viewMap;
    }

    public bool IsInMoved()
    {
        return piece != null;
    }

    public void SaveGroud(Ground ground)
    {
        this.ground = ground;
    }

    public void SaveMap(Map map)
    {
        this.map = map;
    }

    public void SavePiece(PieceOfChest piece)
    {
        this.piece = piece;
    }

    public void SaveViewMap(Ground[,] viewMap)
    {
        this.viewMap = viewMap;
    }
}