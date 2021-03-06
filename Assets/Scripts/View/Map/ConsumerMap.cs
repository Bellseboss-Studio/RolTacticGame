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
        ServiceLocator.Instance.GetService<ICusor>().SaveMap(map);
        ServiceLocator.Instance.GetService<ICusor>().SaveViewMap(viewMap);
        foreach (string[] mapaLogicoString in map.MapDetail)
        {
            width = 0;
            foreach (string detalleDeMapaLogico in mapaLogicoString)
            {
                string ground = detalleDeMapaLogico;
                string piece = "";
                if (detalleDeMapaLogico.Split('-').Length > 1)
                {
                    piece = detalleDeMapaLogico.Split('-')[0];
                    ground = detalleDeMapaLogico.Split('-')[1];

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
                    viewMap[height, width].AddPieceOfChest(pieceInstantiate);
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
                            ground.PrintGroundIsAvalible();
                        }
                    }
                }
            }
        }
    }
}
