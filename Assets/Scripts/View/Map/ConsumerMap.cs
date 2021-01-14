﻿using UnityEngine;

public class ConsumerMap : MonoBehaviour, ICosumerMap
{
    private LogicCosumerMap logic;
    private Ground[,] viewMap;
    private int width;
    private int height;
    [SerializeField] private int separacion;
    [SerializeField] private string nameMap;
    [SerializeField] private GroundConfiguration groundConfiguration;
    [SerializeField] private PieceConfiguration pieceConfiguration;
    [SerializeField] private ControladorDeLogsVisuales logVisual;
    private GroundFactory groundFactory;
    private PieceFactory pieceFactory;

    // Start is called before the first frame update
    void Start()
    {
        groundFactory = new GroundFactory(Instantiate(groundConfiguration));
        pieceFactory = new PieceFactory(Instantiate(pieceConfiguration));
        logic = new LogicCosumerMap(this, nameMap);

    }

    public void PrintMapInTheView(Map map)
    {
        viewMap = new Ground[map.Heigth, map.Width];
        foreach (string[] s in map.MapDetail)
        {
            width = 0;
            foreach (string ss in s)
            {
                string ground = ss;
                string piece = "";
                if (ss.Split('-').Length > 1)
                {
                    piece = ss.Split('-')[0];
                    ground = ss.Split('-')[1];

                }
                viewMap[height, width] = groundFactory.Create(ground);
                viewMap[height, width].name += "|" + height + "_" + width;
                viewMap[height, width].transform.position = new Vector2(transform.position.x + (width * separacion), transform.position.y + (height * separacion));
                viewMap[height, width].transform.parent = transform;
                if(piece != "")
                {
                    PieceOfChest pieceInstantiate = pieceFactory.Create(piece);
                    pieceInstantiate.transform.parent = viewMap[height, width].transform;
                    pieceInstantiate.transform.localPosition = Vector2.zero;
                    viewMap[height, width].AddPieceOfChest(pieceInstantiate, viewMap, map);
                }
                width++;
            }
            height++;
        }
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            logVisual.AgregarLogvisual(touch.phase.ToString());
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D isCollision = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (isCollision.collider != null)
                {
                    logVisual.AgregarLogvisual("Colisiono con algo " + isCollision.collider.gameObject.name);
                    //comprobamos que tenga el componente de Ground
                    if(isCollision.collider.gameObject.TryGetComponent<Ground>(out var ground))
                    {
                        if (!ground.isEmpty())
                        {
                            var piece = ground.GetPiece();
                            foreach (PositionInTable posicion in piece.ListPosicionInTable(ground, viewMap, logic.GetMap()))
                            {
                                if(viewMap[posicion.X, posicion.Y].TryGetComponent<SpriteRenderer>(out var spriteRender))
                                {
                                    spriteRender.color = Color.green;
                                }
                            }
                            Debug.Log("La pieza es: " + piece.Id + " con nombre del gameObect de :" + piece.gameObject.name);
                        }
                    }
                }
            }
        }
    }
}
