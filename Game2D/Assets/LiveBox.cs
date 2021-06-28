using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveBox : MonoBehaviour
{
    public enum LiveSideSubstraction
    {
        Left,
        Right
    }

    public List<Image> heartImage = new List<Image>();

    public Sprite heartFiled = null;
    public Sprite heartEmpty = null;
    public LiveSideSubstraction liveSideSubstraction;

    public bool isSubstaction = false;

    private void Start()
    {
        FindAllObjectHeart();
    }

    private void Update()
    {
        if (isSubstaction)
        {
            GetHeartHud(2,true);
            isSubstaction = false;
        }


    }

    public void GetHeartHud(int countHeartGet,bool isGetHeart)
    {
        for (int j = 0; j<countHeartGet;j++)
        {
            if (liveSideSubstraction == LiveSideSubstraction.Left)
            {
                foreach (Image spriteImage in heartImage)
                {
                    if (spriteImage.sprite == heartFiled)
                    {
                        spriteImage.sprite = heartEmpty;
                        break;
                    }
                }
            }
            else if (liveSideSubstraction == LiveSideSubstraction.Right)
            {
                for (int i = heartImage.Count - 1; i >= 0; i--)
                {
                    if (heartImage[i].sprite == heartFiled)
                    {
                        heartImage[i].sprite = heartEmpty;
                        break;
                    }
                }
            }
        }      
    }

    private void FindAllObjectHeart()
    {
        foreach (Transform heartChild in transform)
        {
            Image imageHeart = heartChild.gameObject.GetComponent<Image>();
            if (imageHeart!=null)
            {
                heartImage.Add(imageHeart);
            }
        }
    }
}
