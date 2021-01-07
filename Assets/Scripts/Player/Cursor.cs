using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public ComponenteMapa puntoDelMapa;
    public GameObject[,] map;
    private GameObject clone;

    public void Init(GameObject[,] map, ComponenteMapa puntoDelMapa)
    {
        this.map = map;
        this.puntoDelMapa = puntoDelMapa;
        transform.parent = this.puntoDelMapa.transform;
        transform.localPosition = Vector2.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            puntoDelMapa = map[puntoDelMapa.altura, puntoDelMapa.anchura - 1].GetComponent<ComponenteMapa>();
            transform.parent = puntoDelMapa.transform;
            transform.localPosition = Vector2.zero;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            puntoDelMapa = map[puntoDelMapa.altura, puntoDelMapa.anchura + 1].GetComponent<ComponenteMapa>();
            transform.parent = puntoDelMapa.transform;
            transform.localPosition = Vector2.zero;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            puntoDelMapa = map[puntoDelMapa.altura + 1, puntoDelMapa.anchura].GetComponent<ComponenteMapa>();
            transform.parent = puntoDelMapa.transform;
            transform.localPosition = Vector2.zero;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            puntoDelMapa = map[puntoDelMapa.altura - 1, puntoDelMapa.anchura].GetComponent<ComponenteMapa>();
            transform.parent = puntoDelMapa.transform;
            transform.localPosition = Vector2.zero;
        }

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                clone = Instantiate(puntoDelMapa.gameObject, transform.position, transform.rotation) as GameObject;
            }
        }
    }
}
