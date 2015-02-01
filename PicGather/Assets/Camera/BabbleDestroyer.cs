﻿using UnityEngine;
using System.Collections;

public class BabbleDestroyer : MonoBehaviour {

    /// <summary>
    /// シャボン玉削除時に生成するGameObject(パーティクル)のプレハブ
    /// </summary>
    [SerializeField]
    private GameObject BabbleParticlePrefab;

    /// <summary>
    /// 現在存在するシャボン玉をすべて削除する
    /// </summary>
    public void DestroyAllBabbles()
    {
        
        GameObject[] Babbles = GameObject.FindGameObjectsWithTag("Babble");

        foreach(var babble in Babbles)
        {
            Destroyer.DestroyAndCreateObject(babble,BabbleParticlePrefab);
        }

    }
}
