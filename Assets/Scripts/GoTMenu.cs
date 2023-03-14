using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoTMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoretxt;
    private void Start()
    {
        scoretxt.text = "Score: " + PlayerMovement.finalscore;
    }
    public void GoToMenu()
    {

        SceneManager.LoadScene("Menu");
    }
}
