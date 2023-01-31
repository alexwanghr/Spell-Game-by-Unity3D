using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayAni
{
    Move=1,
    Stop=2,
    Pick=3,
}
public class PlayerController : MonoBehaviour
{
    public int currLife;
    public Camera cam;
    public InteractTreeUI InteractTreeUI;
    public Animator animator;
    public bool stop;
    private PlayAni currAni;
    public Text warningText;
    public HeartUI heartUI;
    public GameObject GameOverGO;

    private void Start()
    {
        currLife = 3;
        warningText.text = "";
        if (InteractTreeUI == null)
        {
            InteractTreeUI = GameObject.Find("InteractTreeUI").GetComponent<InteractTreeUI>();
        }
        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
    }

    void Update()
    {
        if (stop)
        {
            ChangeAnimator(PlayAni.Stop);
            return;
        }
        float speed = 4f;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * speed;
            ChangeAnimator(PlayAni.Move);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * speed;
            ChangeAnimator(PlayAni.Move);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            ChangeAnimator(PlayAni.Move);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
            ChangeAnimator(PlayAni.Move);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Tree"))
        {
            
            warningText.text = "Hit Tree!";
            if (InteractTreeUI != null)
            {
                TreeObj treeObj = other.GetComponentInParent<TreeObj>();
                if (treeObj.currTree == Tree.tallTree)
                {
                    ChangeSkyBox();
                    return;
                }
                InteractTreeUI.SetCurrTreeObj(other.GetComponentInParent<TreeObj>());
                InteractTreeUI.Show(treeObj.currTree);
                stop = true;
            }
        }
        if (other.gameObject.name.Contains("Monster"))
        {
            warningText.text = "Hit Monster!";
            ChangeLife(false);
        }
    }

    public void ChangeAnimator(PlayAni ani)
    {
        if (currAni == ani)
        {
            return;
        }

        currAni = ani;
        switch (ani)
        {
            case PlayAni.Move:
                animator.SetTrigger("move");
                break;
            case PlayAni.Stop:
                animator.SetTrigger("stop");
                break;
            case PlayAni.Pick:
                animator.SetTrigger("pick");
                break;
        }
    }

    private bool isNight = false;
    public void ChangeSkyBox()
    {
        if (cam.GetComponent<Skybox>() != null)
        {
            isNight = !isNight;
            Debug.Log("isNight="+isNight);
            if (isNight)
            {
                cam.GetComponent<Skybox>().material = Resources.Load<Material>("Night");
            }
            else
            {
                cam.GetComponent<Skybox>().material = Resources.Load<Material>("Day");
            }
        }
    }

    private void ChangeLife(bool add)
    {
        if (heartUI != null)
        {
            if ((currLife == 3 && add) || (currLife == 0 && !add))
            {
                return;
            }
            heartUI.changeLife(add,currLife);
            currLife += add ? 1 : -1;
        }

        if (currLife == 0)
        {
            GameOver();
        }
        Debug.Log("life:" +currLife);
    }

    public void GameOver()
    {
        GameOverGO.SetActive(true);
    }

}
