/// ---------------------------------------------------
/// date ： 2015/02/17  
/// brief ： 音符の移動処理
/// author ： Yamada Masamistu
/// ---------------------------------------------------
/// 
using UnityEngine;
using System.Collections;

public class NoteMover : MonoBehaviour {

    [SerializeField]
    float Speed = 6;

    Vector3 Velocity = Vector3.zero;


	// Use this for initialization
	void Start () {

        Velocity.x = Random.Range(-Speed, Speed);
        Velocity.y = Random.Range(Speed/2, Speed);
        Velocity.z = Random.Range(-Speed, Speed);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Velocity * Time.deltaTime);

        StartCoroutine("AlphaControl");
	}

    /// <summary>
    /// アルファ値の制御
    /// </summary>
    /// <returns></returns>
    IEnumerator AlphaControl()
    {
        yield return new WaitForSeconds(1.5f);

        Velocity *= 0.98f;
        
        var alpha = new Color(0, 0, 0, 0.01f);
        GetComponent<Renderer>().material.color -= alpha;
        if (GetComponent<Renderer>().material.color.a <= 0)
        {
            iTween.Stop(gameObject);
            Destroy(gameObject);
        }
    }

}
