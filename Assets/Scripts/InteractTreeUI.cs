using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractTreeUI : MonoBehaviour
{
    public GameObject content;
    public Button PickBtn;
    public Button CutDownBtn;
    public PlayerController Player;
    private TreeObj currTreeObj;
    public void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        PickBtn.onClick.AddListener(onPickBtnClick);
        CutDownBtn.onClick.AddListener(onCutDownBtnClick);
    }

    public void SetCurrTreeObj(TreeObj obj)
    {
        currTreeObj = obj;
    }
    public void Show(Tree currTree)
    {
        switch (currTree)
        {
            case Tree.appleTree:
                content.SetActive(true);
                break;
            case Tree.normalTree:
                PickBtn.gameObject.SetActive(false);
                content.SetActive(true);
                break;
            case Tree.tallTree:
                break;
        }
    }

    public void Hide()
    {
        content.SetActive(false);
    }

    public void onPickBtnClick()
    {
        Hide();
        Player.ChangeAnimator(PlayAni.Pick);
        Player.stop = false;
    }
    
    public void onCutDownBtnClick()
    {
        if (currTreeObj != null)
        {
            currTreeObj.CutDown();
        }
        Hide();
        Player.stop = false;
    }

}
