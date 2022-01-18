using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }
    public void LoadLevel(int buildAddition)
    {
        StartCoroutine(LoadLevelCo(buildAddition));
    }
    IEnumerator LoadLevelCo(int buildAddition)
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + buildAddition);
    }
}
