using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class letmovethis : MonoBehaviour
{

    [SerializeField]
    Transform ramsMinenono;
    Vector3 moveLength = new Vector3(6.8f, 0, 0);
    float speed = 0.45f;
    private Vector3 originalPosition;
    private bool isTrigged = false;
    int handleMouseButton = 0;


    [Header("GameObject")]
    [SerializeField]
    GameObject choice1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = ramsMinenono.position;
        mainboardOriginalPosition = mainboard.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.press.wasPressedThisFrame && !isTrigged)// ตอนแรก Input.touchCount > 1 ไง พอมาท่านี้เลยลดลงมา
        {
            handleMouseButton++;
            if (handleMouseButton == 2)
            {
                StartCoroutine(moveMeaway());
                isTrigged = true;
            }
        }
        if (Mouse.current != null && Mouse.current.press.wasPressedThisFrame && !isTrigged)
        {
            handleMouseButton++;
            if (handleMouseButton == 2)
            {
                StartCoroutine(moveMeaway());
                isTrigged = true;
            }
        }
    }

    [Header("New comer")]
    [SerializeField]
    Transform mainboard;
    private Vector3 mainboardOriginalPosition;
    Vector3 direction = new Vector3(0.5f, -1.75f, -7.14f);
    IEnumerator moveMeaway() //Yes Yes Yes this way look cools!
    {
        Vector3 moveTarget = originalPosition + moveLength;
        float timersurger = 0;

        while (timersurger < speed)
        {
            ramsMinenono.position = Vector3.Lerp(originalPosition, moveTarget, timersurger / speed);//ram
            timersurger += Time.deltaTime;
            yield return null;
        }
        ramsMinenono.position = moveTarget;
        /* ได้ที่ไหนละ
        //อยากจะขยับต่อจากตรงนี้อีก เขียนตรงนี้เลยได้ไหมหรือต้องสร้าง func ใหม่(จะขยับแกน z ให้มันวิ่งมาหน้ากล้อง)

        Vector3 countinueMove = ramsMinenono.position;
        countinueMove.z += 7f;
        ramsMinenono.position = countinueMove;

        */

        yield return StartCoroutine(letmeMovesomemore());
    }
    IEnumerator letmeMovesomemore() //Test countinue IEnumerator
    {
        Vector3 moreMove = ramsMinenono.position;
        float timersurger = 0;
        float speedUp = 0.78f;
        Vector3 outsideTheView = new Vector3(0, 0, -80f);


        //ทีนี้อยากจะหมุน rotation อะ 
        while (timersurger < speedUp)
        {

            ramsMinenono.position = Vector3.Lerp(moreMove, outsideTheView, timersurger / speedUp);

            timersurger += Time.deltaTime;
            yield return null;              //AKA ด้านใน
        }
        ramsMinenono.position = outsideTheView;
        yield return StartCoroutine(rotationSomemore()); //ไปเรียกใช้"ด้านใน" ไม่ได้นะ คร้าบบ

    }
    IEnumerator rotationSomemore() //mainboard Animation
    {
        Quaternion startRotation = mainboard.rotation;

        Quaternion endRotation = Quaternion.Euler(0, 100f, -75f);

        float rotationTimer = 0f;


        Vector3 movedirection = mainboardOriginalPosition + direction;

        while (rotationTimer < speed)
        {
            float letmehandlerotationTimer = rotationTimer / speed;
            mainboard.position = Vector3.Lerp(mainboardOriginalPosition, movedirection, letmehandlerotationTimer);//mainboard
            mainboard.rotation = Quaternion.Lerp(startRotation, endRotation, letmehandlerotationTimer);


            rotationTimer += Time.deltaTime;
            yield return null;
        }
        mainboard.rotation = endRotation;
        mainboard.position = movedirection;

        choice1.SetActive(true);
    }

}
