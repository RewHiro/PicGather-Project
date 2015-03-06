using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanNotCharacterDrawing : MonoBehaviour {

    [SerializeField]
    CharacterManager Manager = null;

    [SerializeField]
    GameObject NotPrefab = null;

    Button CharaButton = null;

    void Start()
    {
        CharaButton = GetComponent<Button>();
    }

    void Update()
    {
        if (!Manager.CanDrawing)
        {
            Debug.Log(Manager.Name + " : NotDrawing");
            CharaButton.enabled = false;
            NotPrefab.SetActive(true);
        }
        else
        {
            Debug.Log(Manager.Name + " : CanDrawing");

            CharaButton.enabled = true;
            NotPrefab.SetActive(false);
        }
    }


}
