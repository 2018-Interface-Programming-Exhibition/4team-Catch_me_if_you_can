using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class time_1 : MonoBehaviour {

    public void stage_2()
    {
        SceneManager.LoadScene("stage-2");
    }

    public Text timelabel;
    public float timecount = 0;
    private void Update()
    {
        timecount += Time.deltaTime;
        timelabel.text = string.Format("{0:f2}", timecount);
        if (timecount > 10)
            stage_2();
    }
    


}
