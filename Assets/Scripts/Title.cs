using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {
    
    // Start버튼
	public void StartStage()
    {
        SceneManager.LoadScene("Jochiwon");
    }

    //Continue버튼
    public void ContinueStage()
    {

    }
}
