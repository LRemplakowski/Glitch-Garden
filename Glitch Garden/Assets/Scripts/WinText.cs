using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour {

    public void SetToVisivble()
    {
        GetComponent<Text>().color = new Color(0.1596654f, 0.8679245f, 0.1659906f, 1f);
    }
}
