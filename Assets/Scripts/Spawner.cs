﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float fallTime = 0.005f;
    public GameObject Patty_Pool;

    public int PattyNumb = 5;
    public List<GameObject> PoolObjs_P;


    void Start()
    {
        PoolObjs_P = new List<GameObject>();

        for(int i = 0; i< PattyNumb; i++)
        {
            GameObject obj_P = (GameObject)Instantiate(Patty_Pool);
            obj_P.SetActive(false);
            PoolObjs_P.Add(obj_P); ///만들고 비활성화해둔 오브젝트 풀에 저장.
        }

        InvokeRepeating("Fall", fallTime, 1.0f);
    }

    void Fall()
    {
        for(int i =0; i<PoolObjs_P.Count; i++)
        {
            if(!PoolObjs_P[i].activeInHierarchy)
            {
                PoolObjs_P[i].transform.position = transform.position;
                PoolObjs_P[i].transform.rotation = transform.rotation;
                PoolObjs_P[i].SetActive(true);
                break;
            }
        }
    }
}