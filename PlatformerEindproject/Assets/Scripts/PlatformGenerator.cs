using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

  public GameObject thePlatform;
  public Transform generationPoint;
  public float distanceBetween;

  private float platformWidth;

  public float distanceBetweenMin;
  public float distanceBetweenMax;

  private int platformSelector;
  private float[] platformWidths;



  public ObjectPooler[] theObjectPools;

  void Start()
  {
    //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

    platformWidths = new float[theObjectPools.Length];

    for (int i = 0; i < theObjectPools.Length; i++)
    {
      platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.x < generationPoint.position.x)
    {
      distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

      platformSelector = Random.Range(0, theObjectPools.Length);

      transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distanceBetween, transform.position.y, 0);

      //Instantiate(thePlatform, transform.position, transform.rotation);

      GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

      newPlatform.transform.position = transform.position;
      newPlatform.transform.rotation = transform.rotation;
      newPlatform.SetActive(true);
    }
  }
}
