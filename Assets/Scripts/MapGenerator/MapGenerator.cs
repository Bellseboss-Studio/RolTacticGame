using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapGenerator: MonoBehaviour
{
    [SerializeField] private GameObject prefabDePunto;
    [SerializeField] private GameObject roger;
    [SerializeField] private GameObject cursor;
    private int alto, ancho;
    [SerializeField] private float separacion;
    public GameObject[,] map;
    // Start is called before the first frame update
    void Start()
    {
        var file = ReadFile(@"Assets/Resources/map.csv");
        /*for(var i = 0; i < alto; i++)
        {
            for(var o = 0; o < ancho; o++)
            {
                map[i, o] = Instantiate(prefabDePunto);
                map[i, o].name += "_" + i + o;
                map[i, o].transform.position = new Vector2(transform.position.x + (o * separacion), transform.position.y + (i * separacion));
                map[i, o].transform.parent = transform;
            }
        }*/
        map = new GameObject[file.Count, file[0].Length];
        foreach (string[] s in file)
        {
            ancho = 0;
            foreach (string ss in s)
            {
                map[alto, ancho] = FactoriaDeTerreno(ss);
                map[alto, ancho].GetComponent<ComponenteMapa>().altura = alto;
                map[alto, ancho].GetComponent<ComponenteMapa>().anchura = ancho;
                map[alto, ancho].name += "_" + alto + "_" + ancho;
                map[alto, ancho].transform.position = new Vector2(transform.position.x + (ancho * separacion), transform.position.y + (alto * separacion));
                map[alto, ancho].transform.parent = transform;
                ancho++;
            }
            alto++;
        }

        cursor = Instantiate(cursor, map[0, 0].transform) as GameObject;
        cursor.GetComponent<Cursor>().Init(map, map[0, 0].GetComponent<ComponenteMapa>());
    }

    private GameObject FactoriaDeTerreno(string ss)
    {
        var character = "";
        var hayCharacter = ss.Split('-').Length > 1;
        if (hayCharacter)
        {
            character = ss.Split('-')[0];
            ss = ss.Split('-')[1];
        }
        switch (ss)
        {
            case "0":
                prefabDePunto.GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case "1":
                prefabDePunto.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case "2":
                prefabDePunto.GetComponent<SpriteRenderer>().color = Color.green;
                break;
        }
        var go = Instantiate(prefabDePunto) as GameObject;
        GameObject characterInstance = null;
        if (hayCharacter)
        {
            switch (character)
            {
                case "R":
                    characterInstance = Instantiate(roger);
                    break;
            }
            characterInstance.transform.parent = go.transform;
        }
        return go;
    }

    public List<string[]> ReadFile(string path)
    {
        string line;
        List<string[]> result = new List<string[]>();
        // Read the file and display it line by line.  
        StreamReader file = new StreamReader(path);
        while ((line = file.ReadLine()) != null)
        {
            result.Add(line.Split(';'));
        }
        file.Close();
        return result;
    }
}
