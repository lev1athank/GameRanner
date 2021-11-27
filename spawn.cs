using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] GameObject Prefab;

    [SerializeField] Transform camera;

    [Header("random")]
    [SerializeField] bool OnRandom = true;
    [SerializeField] float minRazbros = -1;
    [SerializeField] float MaxRazbros = 2;

    [Header("distant")]
    [SerializeField] float distant = 10f;
    [SerializeField] List<Material> color;
    List<GameObject> wall = new List<GameObject>();
    float Zpoz = 10f;



    int selectIndex = 0;

    private void Awake()
    {
        for(int i = 0; i < 5; i++)
        {
            Zpoz = RandomPoz();
            GameObject wallObj = Instantiate(Prefab, new Vector3(0, 0, Zpoz), Quaternion.identity);
            RandomColor(wallObj);
            wall.Add(wallObj);

        }
    }

    private float RandomPoz()
    {
        if (OnRandom)
            Zpoz += UnityEngine.Random.Range(minRazbros, MaxRazbros) + distant;
        else
            Zpoz += distant;
        return Zpoz;
    }

    private void RandomColor(GameObject walls)
    {
        int size = 4;
        int bleck = 0;
        foreach (Renderer wall in walls.GetComponentsInChildren<Renderer>())
        {
            
            int cl = UnityEngine.Random.Range(0, size);
            if(bleck == 2)
            {
                size--;
                cl = UnityEngine.Random.Range(0, size);
            }
            if(cl == 3) { bleck++; }
            wall.material.color = color[cl].color;
        }
        size = 4;
        bleck = 0;
    }

    private void Update()
    {
        if(wall[selectIndex].transform.position.z < camera.position.z)
        {
            wall[selectIndex].transform.position = new Vector3(0, 0, RandomPoz());
            RandomColor(wall[selectIndex]);
            if(selectIndex == 4)
            {
                selectIndex = 0;
            }else
            {
                selectIndex++;
            }

        }
    }
}
