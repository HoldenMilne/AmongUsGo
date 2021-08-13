using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminPanelHider : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        // grab the correct object maybe?
    }

    private bool open = false;

    private float time = 0;

    public float sleepDelay = 3;
    // Update is called once per frame
    private bool keyDown = false;
    void Update()
    {
        if (!open && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 || (Input.anyKey && !keyDown)))
        {
            ShowHideCover(true);
            open = true;
            time = Time.time;
            keyDown = true;
        }
        
        if (Input.anyKey)
        {
            time = Time.time;
        }
        else
        {
            keyDown = false;
        }

        if (open && Time.time-time>sleepDelay)
        {
            open = false;
            ShowHideCover(false);
        }
    }

    private IEnumerator WakeUp()
    {
        ShowHideCover(true);
        yield return null;
    }


    public void ShowHideCover(bool hide)
    {
        StopAllCoroutines();
        if (hide)
        {
            StartCoroutine(HideCover());
        }
        else
        {
            StartCoroutine(ShowCover());
        }
    }
    

    private IEnumerator HideCover()
    {
        var a = canvasGroup.alpha;
        while (a > 0f)
        {
            canvasGroup.alpha = a;
            a -= Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
    private IEnumerator ShowCover()
    {
        var a = canvasGroup.alpha;
        while (a < 1f)
        {
            canvasGroup.alpha = a;
            a += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}
