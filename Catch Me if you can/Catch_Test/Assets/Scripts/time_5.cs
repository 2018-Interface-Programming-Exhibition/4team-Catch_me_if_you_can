using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class time_5 : MonoBehaviour
{

    public void winner()
    {
        SceneManager.LoadScene("winner");
    }

    public Text timelabel;
    public float timecount = 0;
    private void Update()
    {
        timecount += Time.deltaTime;
        timelabel.text = string.Format("{0:f2}", timecount);
        if (timecount >= 60)
            winner();
    }



}