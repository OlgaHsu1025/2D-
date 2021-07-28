using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    [SerializeField] GameObject AgainButton;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0;
        AgainButton.SetActive(true);

        other.transform.root.SendMessage("SaveScore", SendMessageOptions.DontRequireReceiver);
    }
    public void OnAgainButton()
    {
        SceneManager.LoadScene("Game");
            
    }
}
