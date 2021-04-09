using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(ClickStoper());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ClickStoper(){
        panel.SetActive(true);
        yield return new WaitForSeconds(1);
        panel.SetActive(false);
    }
}
