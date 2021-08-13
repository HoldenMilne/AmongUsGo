using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashController : MonoBehaviour
{
    public Image logo;
    public Image bg;
    public AudioSource source;
    private AsyncOperation loadScene;

    public CanvasGroup canvasGroup;
    public string sceneName = "IntroScene";

    private string currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        loadScene = SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
        StartCoroutine(Play());
    }

    public bool isLoaded()
    {
        return loadScene.isDone;
    }
    private IEnumerator Play()
    {
        yield return new WaitForSeconds(.5f);
        var a = 0f;
        var c = bg.color;
        a = 0;
        while (a < 1)
        {
            a += Time.deltaTime * 1.1f;
            c.a = a;
            bg.color = c;
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        a = 0;
        c = logo.color;
        c.a = 0;
        while (a < 1f)
        {
            a += Time.deltaTime * 15f;
            if (c.a < 0.5f && a >= 0.5f)
            {
                source.Play();
            }
            c.a = a;
            logo.color = c;
            yield return null;
        }

        yield return new WaitForSeconds(3f);
        yield return new WaitUntil(isLoaded);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        a = 1;
        while (a > 0)
        {
            a -= Time.deltaTime * 1.1f;
            canvasGroup.alpha = a;
            yield return null;
        }

        if (sceneName.Equals("PCIntroScene", StringComparison.InvariantCultureIgnoreCase))
        {
            FindObjectOfType<ScrollLerp>().StartLerp();
        }
        SceneManager.UnloadSceneAsync(currentScene);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
