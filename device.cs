using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class device : MonoBehaviour
{
    [SerializeField] private Transform pivotPointPosition;
    [SerializeField] private GameObject laser;

    private bool turnedOnOff;
    // Start is called before the first frame update
    void Start()
    {
        turnedOnOff = false;   
        laser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TurnDeviceOn_Off(turnedOnOff);

    }

    private void TurnDeviceOn_Off(bool turnOpen)
    {
        if(turnOpen==true) 
        {
            if (pivotPointPosition.rotation.eulerAngles.y < 90)
                transform.RotateAround(pivotPointPosition.position, Vector3.up, 20 * Time.deltaTime);
            if (pivotPointPosition.rotation.eulerAngles.y < 90 && pivotPointPosition.rotation.eulerAngles.y > 89)
            {
                laser.SetActive(turnOpen);
                StartCoroutine(LaserLife());
            }
        }
        else if (turnOpen == false) 
        {
            laser.SetActive(turnOpen);
            if (pivotPointPosition.rotation.eulerAngles.y > 1)
                transform.RotateAround(pivotPointPosition.position, Vector3.down, 20 * Time.deltaTime);
        }
    }
    public bool OnOffButton()
    {
        if(turnedOnOff==false) 
            turnedOnOff=true;
        else 
            turnedOnOff = false;
        return turnedOnOff;
    }

    IEnumerator LaserLife()
    {
        yield return new WaitForSeconds(5);
        turnedOnOff=false;
    }
}
