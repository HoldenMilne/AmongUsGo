using UnityEngine;


//[ExecuteInEditMode]
public class WallSetter : MonoBehaviour
{
    public bool setPlacerPosition = false;
    public bool setObjectPosition = false;

    public bool horizontal = false;
    public RectTransform placer;
    // Start is called before the first frame update
    void Start()
    {
        SetObjectPosition();
        SetObjectSize();
    }

    // Update is called once per frame
    void Update()
    {
        if (setPlacerPosition)
        {
            SetPlacerPosition();
            setPlacerPosition = false;
        }

        if (setObjectPosition)
        {
            SetObjectPosition();
            SetObjectSize();
            setObjectPosition = false;
            
        }
        

    }

    private void SetObjectSize()
    {
        var cam = Camera.main;
        if (horizontal)
        {
            var y = (cam.ScreenToWorldPoint(placer.rect.center) -
                     cam.ScreenToWorldPoint(placer.rect.center + Vector2.up * placer.rect.height/1f)).magnitude /4f;
            var bc = transform.GetComponent<BoxCollider2D>();
            bc.size = new Vector2(bc.size.x, y);
        }

        else
        {
            var x = (cam.ScreenToWorldPoint(placer.rect.center) -
                     cam.ScreenToWorldPoint(placer.rect.center + Vector2.right * placer.rect.width/1f)).magnitude /4f;
            var bc = transform.GetComponent<BoxCollider2D>();
            bc.size = new Vector2(x, bc.size.y);
        }
    }


    private void SetObjectPosition()
    {
        transform.position = placer.position;
        
        
    }

    private void SetPlacerPosition()
    {
        placer.position = transform.position;
    }

}
