using System;
using UnityEngine;

public class TouchInputSystemManager : InputSystemManager
{
    public Action<Vector2> OnTouchBegin;
    public Action<Vector2> OnTouchMoved;
    public Action<Vector2> OnTouchEnd;

    private void Update()
    {
        if(enableInputListener && Input.touchCount > 0)
        {
            var theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                OnTouchBegin?.Invoke(theTouch.deltaPosition);
            }

            if (theTouch.phase == TouchPhase.Moved)
            {
                OnTouchMoved?.Invoke(theTouch.deltaPosition);   
            }

            if (theTouch.phase == TouchPhase.Ended)
            {
                OnTouchEnd?.Invoke(theTouch.deltaPosition);
            }
        }
    }
}
