using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockFPSSelector : MonoBehaviour
{
    public int frameRateOption1;
    public int frameRateOption2;
    public int frameRateOption3;
    public int frameRateOption4;
    public int frameRateOption5;
    public int frameRateOption6;

    private static LockFPSSelector instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Application.targetFrameRate = -240;
    }

    public void FrameRate1()
    {
        Application.targetFrameRate = frameRateOption1;
    }

    public void FrameRate2()
    {
        Application.targetFrameRate = frameRateOption2;
    }

    public void FrameRate3()
    {
        Application.targetFrameRate = frameRateOption3;
    }

    public void FrameRate4()
    {
        Application.targetFrameRate = frameRateOption4;
    }

    public void FrameRate5()
    {
        Application.targetFrameRate = frameRateOption5;
    }

    public void FrameRate6()
    {
        Application.targetFrameRate = -1;
    }
}
