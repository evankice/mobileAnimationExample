using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class TouchController : MonoBehaviour
{
    // public DinoController dino;
    public Camera camera;
    public Transform pointer;

    public float tapRadius = 0.5f;

    public Dictionary<int,TouchInfo> touchInfos = new Dictionary<int, TouchInfo>();

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        Debug.Log(Screen.dpi);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Finger eachFinger in Touch.activeFingers)
        {
            Touch touch = eachFinger.currentTouch;

            float tapDistance = Vector2.Distance(touch.screenPosition,touch.startScreenPosition) / Screen.dpi;

            if(touch.phase == TouchPhase.Began)
            {
                TouchInfo newTouchInfo = new TouchInfo();
                newTouchInfo.touchId = touch.touchId;
                if(!touchInfos.ContainsKey(touch.touchId))
                {
                    touchInfos.Add(touch.touchId,newTouchInfo);
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                if(tapDistance > tapRadius)
                {
                    Vector2 moveDirection = (touch.screenPosition - touch.startScreenPosition) / Screen.dpi;
                    // Debug.Log(moveDirection);
                    // if(dino != null)
                    // {
                    //     dino.MoveWithVector(moveDirection);
                    //     if(touchInfos.TryGetValue(touch.touchId, out TouchInfo info))
                    //     {
                    //         info.isUsedForJoystick = true;
                    //     }
                    // }
                }
            }
            if(touch.phase == TouchPhase.Ended)
            {
                TouchInfo info = new TouchInfo();
                touchInfos.TryGetValue(touch.touchId, out info);

                if(tapDistance < tapRadius && !info.isUsedForJoystick) // This is a tap!!
                {
                    // Debug.Log("Tap!");

                    if(camera != null)
                    {
                        Vector3 realWorldTapPosition = camera.ScreenToWorldPoint(new Vector3(touch.screenPosition.x, touch.screenPosition.y, camera.nearClipPlane));
                        pointer.position = realWorldTapPosition;
                        Collider2D thingITapped = Physics2D.OverlapCircle(new Vector2(realWorldTapPosition.x,realWorldTapPosition.y), 1);
                        if(thingITapped != null)
                        {

                        }
                        else
                        {
                            // if(dino != null)
                            // {
                            //     dino.Jump();
                            // }
                        }
                    }
                }
                else
                {
                    // if(dino != null)
                    // {
                    //     dino.MoveWithVector(Vector2.zero);
                    // }
                }
            }
        }
    }
}

public class TouchInfo
{
    public int touchId;
    public bool isUsedForJoystick = false;
}