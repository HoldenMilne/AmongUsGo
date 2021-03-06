using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleController : MonoBehaviour
{
    public float garbageImpulse = 1f;
    //public RectTransform handleBase;
    // private RectTransform handle;
    
    public Transform handleBase;
    private Transform handle;

    public BoxCollider2D bottomWall;
    private bool pressed = false;

    private GameController gc;

    private float maxY;
    private float minY;
    // Start is called before the first frame update
    void Start()
    {
        handle = GetComponent<RectTransform>();
        gc = FindObjectOfType<GameController>();
        if (gc == null)
        {
            gc = GameController.CreateGC();
        }

        maxY = handle.position.y;
        minY = handleBase.position.y * 2 - maxY;

        StartCoroutine(ErrorCatchAll());
    }

    private IEnumerator ErrorCatchAll()
    {
        yield return new WaitForSeconds(10f);
        var timer = 0f;
        while (true)
        {

            var v = CheckVelocities();
            if (v < 0.05f)
            {
                timer += Time.deltaTime;

                if (timer > 8)
                {
                    Debug.Log("ERROR WITH THE EMPTY TRASH SYSTEM.");
                    yield break;
                }
            }
            else
            {
                timer = 0;
            }
            yield return null;
        }
    }

    private float CheckVelocities()
    {
        var tot = 0f;
        var gcs = FindObjectsOfType<GarbageController>();
        foreach (var f in gcs)
        {
            tot += f.GetComponent<Rigidbody>().velocity.magnitude;
        }

        return tot / gcs.Length;
    }


    private float time;
    private float timeDelay = 8f;

    public void OnClick()
    {
        if (!pressed)
            time = Time.time;
        pressed = true;
        
    }
    
    public void OnRelease()
    {
        time = Time.time;
        pressed = false;
    }

    private bool success;

    private bool done;
    // Update is called once per frame
    void Update()
    {
        if (pressed && !success)
        {
            var touch = gc.GetTouch(true);
        
            var pos = handle.position;
            pos.y = Mathf.Max(touch.y,minY);
            pos.y = Mathf.Min(pos.y,maxY);
            handle.position = pos;

            if (pos.y <= minY+0.01 || Time.time - time >timeDelay)
            {
                success = true;
                StartCoroutine(Success());
            }
                
        }
        else if(!success || (done&&!pressed))
        {
            // move back to initial position;
            var touch2 = gc.GetTouch(true);
            var pos = handle.position;
            pos.y = Mathf.Lerp(pos.y,maxY,Time.deltaTime*4f);
            handle.position = pos;
        }
    }

    private bool gone;
    bool GarbageExists()
    {
       
        return pressed && CheckExists();
    }

    bool CheckExists()
    {
        var l = FindObjectsOfType<Rigidbody2D>().Length;
        Debug.Log(l+ "<RIGH");
         return l > 4;
    }
    IEnumerator Success()
    {
        bottomWall.enabled = false;
        GarbageController.CallOnAll(garbageImpulse);
        yield return new WaitWhile(GarbageExists);
        if (!pressed)
        {
            success = false;
            bottomWall.enabled = true;
            yield break;
        }

        done = true;
        Debug.Log("SUCCESS");
        
        gc.Report();
    }
}
