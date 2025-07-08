using UnityEngine;
using UnityEngine.InputSystem;

public class firsttouchme : MonoBehaviour
{
    //จะรับค่าการกดหน้าจอได้ไง project นี้ เป็น 3d mobile game ไง ไม่รู้เลย
    [Header("GameObject")]
    [SerializeField]
    GameObject Somethingidk;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        /*      Test ระบบ
        
        if (Input.touchCount > 0 && Input.GetMouseButtonDown(0))
        {

            fingerTouchingScreenLOL = Input.GetTouch(0);

            if (fingerTouchingScreenLOL.phase == TouchPhase.Began)
            {
                //จะ set active somethingidk ได้ยังไงนะลืมละ

                somethingidk.SetActive(false);

                //อะเคร Thx💕
            }
        }
*/

        // int touchmytalala = Input.GetTouch(0).tapCount;
        //Touch touchMyhand = Input.GetTouch(0);
        //int touchmytalala = touchMyhand.tapCount;

        // if (Input.GetMouseButtonDown(0))
        // {
        //     Somethingidk.SetActive(false);
        // }
        /*      อัน Input System (old)
                //ต้องท่านี้เท่านั้น mobile security Copilot ว่างั้น
                if (Input.touchCount > 0)
                {
                    int touchmytalala = Input.GetTouch(0).tapCount;
                    if (touchmytalala > 0)
                    {
                        Somethingidk.SetActive(false);
                    }
                }
                */



        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            GameObject.Destroy(Somethingidk);
        }
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject.Destroy(Somethingidk);
        }
    }
}
