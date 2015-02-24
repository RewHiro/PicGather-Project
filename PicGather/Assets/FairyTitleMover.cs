using UnityEngine;
using System.Collections;

public class FairyTitleMover : MonoBehaviour {

    [SerializeField]
    float GoalTime = 3.0f;

    [SerializeField]
    GameObject ChangeFairy = null;

    Animator Anima;

    float Duration = 0;

	// Use this for initialization
	void Start () {
        Anima = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator WaitOnComing()
    {
        yield return new WaitForSeconds(Duration / 2);
        
        var clone = (GameObject)Instantiate(ChangeFairy, transform.position, ChangeFairy.transform.rotation);
        clone.transform.parent = Camera.main.transform;

        Destroy(gameObject);

    }

    /// <summary>
    /// スタートアニメーション
    /// </summary>
    public void StartAnimation()
    {
        Anima.SetTrigger("OnWakeUpTrigger");

        var currentState = Anima.GetCurrentAnimatorStateInfo(0);
        Duration = currentState.length;
        
        StartCoroutine("WaitOnComing");
    }

}
