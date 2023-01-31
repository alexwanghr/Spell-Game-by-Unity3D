using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tree
{
    appleTree,
    normalTree,
    tallTree
}
public class TreeObj : MonoBehaviour
{
    public Tree currTree;
    public BoxCollider tree;
    public GameObject fruitModel;
    public Transform appleTree;
    public Transform normalTree;
    public Transform tallTree;

    public void Start()
    {
        appleTree.gameObject.SetActive(false);
        normalTree.gameObject.SetActive(false);
        tallTree.gameObject.SetActive(false);
        switch (currTree)
        {
            case Tree.appleTree:
                appleTree.gameObject.SetActive(true);
                break;
            case Tree.normalTree:
                normalTree.gameObject.SetActive(true);
                break;
            case Tree.tallTree:
                tallTree.gameObject.SetActive(true);
                break;
        }
    }

    public void CutDown()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }
    
}
