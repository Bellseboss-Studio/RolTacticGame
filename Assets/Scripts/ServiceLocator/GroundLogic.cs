public class GroundLogic
{
    private IGroundView groundView;

    public PieceOfChest Piece { get; set; }

    public GroundLogic(IGroundView groundView)
    {
        this.groundView = groundView;
    }

    public void AddPieceOfChest(PieceOfChest piece)
    {
        this.Piece = piece;
    }
    public PieceOfChest GetPiece()
    {
        if (isEmpty())
        {
            throw new GetPieceOfChessNotExist("The piece in this ground not exist");
        }
        return Piece;
    }
    public bool isEmpty() => Piece == null;


    public void ColocarColorOriginalAlGround()
    {
        var mapp = ServiceLocator.Instance.GetService<ICusor>().GetMap();
        var viewMap = ServiceLocator.Instance.GetService<ICusor>().GetViewMap();
        for (var X = 0; X < mapp.Heigth; X++)
        {
            for (var Y = 0; Y < mapp.Width; Y++)
            {
                groundView.ChangedColor(viewMap[X, Y]);
            }
        }
    }

    internal void PrintGroundIsAcalible(Ground ground)
    {
        if (!ground.isEmpty())
        {
            if (ServiceLocator.Instance.GetService<ICusor>().IsInMoved())
            {
                if (!ServiceLocator.Instance.GetService<ITurnSystem>().IsTheTurnForThisPiece(ServiceLocator.Instance.GetService<ICusor>().GetPiece()))
                {
                    return;
                }
                if (!TheMovivedIsLegal(ground))
                {
                    var pieceSaved = ServiceLocator.Instance.GetService<ICusor>().GetPiece();
                    pieceSaved.Restart();
                    SearchGroundForInsertPieceSaved(ServiceLocator.Instance.GetService<ICusor>().GetGround(), pieceSaved);
                    ServiceLocator.Instance.GetService<ICusor>().CleanPiece();
                    ServiceLocator.Instance.GetService<ICusor>().CleanGround();
                    ColocarColorOriginalAlGround();
                    return;
                }
                if (ThePieceYouAreTringToKillIsTheOwnSide(ServiceLocator.Instance.GetService<ICusor>().GetPiece(), ground.GetPiece()))
                {
                    return;
                }
                groundView.DestroyObject(ground.GetPiece().gameObject);
                ground.SetPiece(ServiceLocator.Instance.GetService<ICusor>().GetPiece());
                ground.GetPiece().transform.SetParent(ground.transform);
                groundView.ChangedLocalPositionToZero(ground.GetPiece());
                ServiceLocator.Instance.GetService<ICusor>().CleanPiece();
                ServiceLocator.Instance.GetService<ICusor>().CleanGround();
                ColocarColorOriginalAlGround();
                ServiceLocator.Instance.GetService<ITurnSystem>().ThePlayerMove();
                ServiceLocator.Instance.GetService<IServiceOfDies>().ResetDice();
                return;
            }
            if (!ServiceLocator.Instance.GetService<ITurnSystem>().IsTheTurnForThisPiece(ground.GetPiece()))
            {
                return;
            }
            var actualyPiece = ground.GetPiece();
            try
            {
                var pieceOfMoved = ServiceLocator.Instance.GetService<IServiceOfDies>().GetIdPiece();
                if (!actualyPiece.Id.Contains(pieceOfMoved))
                {
                    throw new PieceInMovedIsIlegal("La piesa que deseas mover no puede ser porque no es la que toca");
                }
            }
            catch (IsNotAvalibleForThrowDice e)
            {
                throw e;
            }


            ServiceLocator.Instance.GetService<ICusor>().SavePiece(actualyPiece);
            ground.SetPiece(null);
            var viewMap = ServiceLocator.Instance.GetService<ICusor>().GetViewMap();
            foreach (PositionInTable posicion in actualyPiece.ListPosicionInTable(ground))
            {
                groundView.ChangedColorToMove(viewMap[posicion.X, posicion.Y]);
            }
            ServiceLocator.Instance.GetService<ICusor>().SaveGroud(ground);
            return;
        }

        if (!ServiceLocator.Instance.GetService<ICusor>().IsInMoved())
        {
            return;
        }

        var piece = ServiceLocator.Instance.GetService<ICusor>().GetPiece();
        var groundSaved = ServiceLocator.Instance.GetService<ICusor>().GetGround();

        if (TheMovivedIsLegal(ground))
        {
            ground.SetPiece(piece);
            ground.GetPiece().transform.SetParent(ground.transform);
            groundView.ChangedLocalPositionToZero(ground.GetPiece());
            ServiceLocator.Instance.GetService<ITurnSystem>().ThePlayerMove();
            ServiceLocator.Instance.GetService<IServiceOfDies>().ResetDice();
        }
        else
        {
            groundSaved.SetPiece(piece);
            groundSaved.GetPiece().transform.SetParent(groundSaved.transform);
            groundView.ChangedLocalPositionToZero(groundSaved.GetPiece());
            groundSaved.GetPiece().Restart();
        }
        ServiceLocator.Instance.GetService<ICusor>().CleanPiece();
        ServiceLocator.Instance.GetService<ICusor>().CleanGround();
        ColocarColorOriginalAlGround();
    }

    public void SearchGroundForInsertPieceSaved(Ground groundTarget, PieceOfChest pieceSaved)
    {
        var mapp = ServiceLocator.Instance.GetService<ICusor>().GetMap();
        var viewMap = ServiceLocator.Instance.GetService<ICusor>().GetViewMap();
        for (var X = 0; X < mapp.Heigth; X++)
        {
            for (var Y = 0; Y < mapp.Width; Y++)
            {
                if (viewMap[X, Y].name.Equals(groundTarget.name))
                {
                    viewMap[X, Y].AddPieceOfChest(pieceSaved);
                }
            }
        }
    }
    public bool ThePieceYouAreTringToKillIsTheOwnSide(PieceOfChest pieceOfChest, PieceOfChest pieceOfChest1)
    {
        if (pieceOfChest.ThisPieceIsWhite())
        {
            return pieceOfChest.ThisPieceIsWhite() && pieceOfChest1.ThisPieceIsWhite();
        }
        else
        {
            return !pieceOfChest.ThisPieceIsWhite() && !pieceOfChest1.ThisPieceIsWhite();
        }
    }
    public bool TheMovivedIsLegal(Ground ground)
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