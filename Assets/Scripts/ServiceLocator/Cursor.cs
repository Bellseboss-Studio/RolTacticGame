public class Cursor : ICusor
{
    private Ground ground;
    private PieceOfChest piece;

    public Ground GetGround()
    {
        return ground;
    }

    public PieceOfChest GetPiece()
    {
        return piece;
    }

    public void SaveGroud(Ground ground)
    {
        this.ground = ground;
    }

    public void SavePiece(PieceOfChest piece)
    {
        this.piece = piece;
    }
}