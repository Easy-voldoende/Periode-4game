using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int objectiveCount;
    void Start()
    {
        objectiveCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Cure cure = GameObject.Find("Player").GetComponent<Cure>();
        if (cure.ingredient1 == true)
        {

        }
        if (cure.ingredient4 == true)
        {

        }
        if (cure.ingredient3 == true)
        {

        }
        if (cure.ingredient2 == true)
        {

        }
    }
}
