using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class time_2 : MonoBehaviour
{

    public void stage_3()
    {
        SceneManager.LoadScene("stage-3");
    }

    public Text timelabel;
    public float timecount = 0;
    private void Update()
    {
        timecount += Time.deltaTime;
        timelabel.text = string.Format("{0:f2}", timecount);
        if (timecount > 10)
            stage_3();
    }



}