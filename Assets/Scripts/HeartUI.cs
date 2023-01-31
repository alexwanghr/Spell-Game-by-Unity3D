using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartUI : MonoBehaviour
{
    public Sprite heart;
    public Sprite noheart;
    public List<Image> heartImg = new List<Image>();
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public void changeLife(bool add, int currlife)
    {
        if (add)
        {
            heartImg[currlife - 1].sprite = heart;
        }
        else
        {
            heartImg[currlife - 1].sprite = noheart;
        }
    }
}
