using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBackground : MonoBehaviour
{
    [SerializeField] float rollSpeed = -1;
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = this.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        var offset = new Vector2(0,rollSpeed * Time.deltaTime);
        material.mainTextureOffset += offset;
    }
}
