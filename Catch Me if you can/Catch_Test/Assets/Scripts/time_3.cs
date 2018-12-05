using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class time_3 : MonoBehaviour
{

    public void stage_4()
    {
        SceneManager.LoadScene("stage-4");
    }

    public Text timelabel;
    public float timecount = 0;
    private void Update()
    {
        timecount += Time.deltaTime;
        timelabel.text = string.Format("{0:f2}", timecount);
        if (timecount > 10)
            stage_4();
    }



}
