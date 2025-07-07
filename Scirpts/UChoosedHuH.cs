using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class UChoosedHuH : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField]
    private GameObject SomeThingsORRam;
    [SerializeField]
    private GameObject FatherBoard;


    [Header("Direction Position")]
    [SerializeField] public float PositionZ;
    [SerializeField] public float PositionX;
    [SerializeField] public float PositionY;


    [Header("Direction Rotation")]
    [SerializeField] public float RotationZ;
    [SerializeField] public float RotationX;
    [SerializeField] public float RotationY;


    private float animaSpeed = 1.7f;

    public void WecanStartwithDefaultsPosition()
    {

        if (SomeThingsORRam == null || FatherBoard == null)
        {
            Debug.LogError("SomeThingsORRam or FatherBoard is not assigned in the inspector.");
            return;
        }
        GameObject gothgirlHandlethisthings = Instantiate(SomeThingsORRam, new Vector3(0, 0, 0), Quaternion.Euler(-0.52f, 0.78f, 5.9f), FatherBoard.transform);
        Vector3 newScale = new Vector3(0.75f, 1f, 1f);
        Transform gothgirlTransform = gothgirlHandlethisthings.transform;
        gothgirlTransform.localScale = newScale;
        //เช็คว่า GameObject ถูกสร้างขึ้นหรือไม่ สร้างแล้วค่อยใช้ StartCoroutine
        StartCoroutine(fixedMainBoard(gothgirlTransform));

    }
    IEnumerator fixedMainBoard(Transform gothgirl)
    {
        // Set the position and rotation of the FatherBoard
        Quaternion currentRotation = FatherBoard.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 100f, 0);

        Vector3 currentPosition = FatherBoard.transform.position;
        Vector3 targetPosition = new Vector3(0, FatherBoard.transform.position.y, 4.31f);

        float duration = 0f;

        while (duration < animaSpeed)
        {
            //หมุน FatherBoard หน่อยเอาตำแหน่งตาม AfterChoosed.cs

            FatherBoard.transform.position = Vector3.Lerp(currentPosition, targetPosition, duration / animaSpeed);
            FatherBoard.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, duration / animaSpeed);
            duration += Time.deltaTime;
            yield return null;
        }
        FatherBoard.transform.position = targetPosition;
        FatherBoard.transform.rotation = targetRotation;
        yield return StartCoroutine(NowRotation(gothgirl));
    }
    IEnumerator NowRotation(Transform gothgirl)
    {
        Vector3 targetPosition = new Vector3(PositionX, PositionY, PositionZ);
        Vector3 currentPosition = gothgirl.position;

        float duration = 0f;
        while (duration < animaSpeed)
        {
            gothgirl.position = Vector3.Lerp(currentPosition, targetPosition, duration / animaSpeed); duration += Time.deltaTime;
            yield return null;
        }
        gothgirl.position = targetPosition;
    }
}
