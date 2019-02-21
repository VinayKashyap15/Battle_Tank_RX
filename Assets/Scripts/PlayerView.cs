using System.Collections;
using System.Collections.Generic;
using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    IDisposable _stopCoroutine;
    // Use this for initialization
    void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_=>
            Debug.Log("Update call hai"));
        this.OnCollisionEnterAsObservable()
            .Subscribe(collision =>
            {
                Debug.Log(collision.gameObject.name);
            });
        var testCoroutine = Observable.FromCoroutine(TestCoroutine1).SelectMany(TestCoroutine2).Subscribe();
       // _stopCoroutine = Observable.FromCoroutine(TestCoroutine1).SelectMany(TestCoroutine2).Subscribe();
    }

    private IEnumerator TestCoroutine1()
    {
        Debug.Log("inside 1st test");
        yield return new WaitForSeconds(5);
        Debug.Log("inside 1st test after 5 seconds");
    }
    private IEnumerator TestCoroutine2()
    {
        Debug.Log("inside 2nd test");
        yield return new WaitForSeconds(2);
        Debug.Log("inside 2nd test after 2 seconds");
    }


}
