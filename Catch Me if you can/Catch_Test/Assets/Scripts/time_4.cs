using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class time_4 : MonoBehaviour
{

    public void stage_5()
    {
        SceneManager.LoadScene("stage-5");
    }

    public Text timelabel;
    public float timecount = 0;
    private void Update()
    {
        timecount += Time.deltaTime;
        timelabel.text = string.Format("{0:f2}", timecount);
        if (timecount >= 60)
            stage_5();
    }



}

