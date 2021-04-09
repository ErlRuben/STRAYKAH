using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 throwDirection;
    private CameraAnimScript camScript;
    private float defaultKickForce, kickForce;
    private float directionMultiplier, forceMultiplier;

    private bool isAnim = true;
    public Text powerText;
    public GameObject Stoper;

    public GameObject arrowGuide, arrowObject;
    // Start is called before the first frame update
    void Start(){
        camScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraAnimScript>();

        powerText = GameObject.FindGameObjectWithTag("powerLevel").GetComponent<Text>();
        rb = gameObject.GetComponent<Rigidbody>();
        throwDirection = new Vector3(150, 50, 150);
        defaultKickForce = 750f;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;

        if(!isAnim){
            if(Input.GetAxis("Mouse X")<0){
                arrowGuide.transform.Rotate(0, -100 * Time.deltaTime, 0);
            }
            if(Input.GetAxis("Mouse X")>0){
                arrowGuide.transform.Rotate(0, 100 * Time.deltaTime, 0);
            }

            
            if(arrowGuide.transform.localRotation.eulerAngles.y < 320  && arrowGuide.transform.localRotation.eulerAngles.y > 180){
                arrowGuide.transform.localEulerAngles = new Vector3(0, -40, 0);
            }
            else if(arrowGuide.transform.localRotation.eulerAngles.y > 40  && arrowGuide.transform.localRotation.eulerAngles.y < 180){
                arrowGuide.transform.localEulerAngles = new Vector3(0, 40, 0);
            }
        }
        else{
            isAnim = camScript.isAnimating;
        }
    }

    public void StartKick(){
        StartCoroutine(ClickStoper());
    }
    IEnumerator ClickStoper(){
        Stoper.SetActive(true);
        float angle = arrowGuide.transform.localRotation.eulerAngles.y;
        float angleOffset = arrowObject.transform.localEulerAngles.y;

        angle = (angle > 180) ? angle - 360 : angle; // converts to negative angle if angled to the left
        angleOffset = (angleOffset > 180) ? angleOffset - 360 : angleOffset;

        Debug.Log("Angle: " + angle);
        Debug.Log("Angle Offset " + angleOffset);
        Debug.Log(throwDirection);

        directionMultiplier = (angle+angleOffset) / 40;
        throwDirection.x *= directionMultiplier;

        Debug.Log("DIrection multiplier: " + directionMultiplier);

        forceMultiplier = (float)int.Parse(powerText.text)/100;
        kickForce = defaultKickForce * forceMultiplier;

        rb.useGravity = true;
        rb.AddForce(throwDirection.normalized * kickForce);

        throwDirection = new Vector3(150, 50, 150);
        yield return new WaitForSeconds(3);
        Stoper.SetActive(false);
    }
}