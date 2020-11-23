using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] GameObject unlock;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    public void UnLock(bool isunLock)
    {
        if(isunLock)
            unlock.SetActive(false);
        else
        {
            unlock.SetActive(true);
            SetStars(0);
        }
    }
    public void SetStars(int i)
    {
        if(i == 1)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
        else if( i== 2)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        else if(i==3)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }

}
