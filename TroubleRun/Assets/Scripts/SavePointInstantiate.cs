using TMPro;
using UnityEngine;
using YG;

public class SavePointInstantiate : MonoBehaviour
{
    public GameObject savePoint;
    public TMP_Text savePointsCount;

    private void Start() { savePointsCount.text = YandexGame.savesData.savePointsCount.ToString(); }

    private void Update()
    {
        if (YandexGame.savesData.savePointsCount > 0 && Input.GetKeyDown(KeyCode.J))
        {
            if (gameObject.GetComponent<CharacterControls>().IsGrounded()) 
            { 
                Instantiate(savePoint, new Vector3(transform.position.x, transform.position.y-1, transform.position.z), Quaternion.identity); 
                YandexGame.savesData.savePointsCount--;
                savePointsCount.text = YandexGame.savesData.savePointsCount.ToString();
                YandexGame.SaveProgress();
            } 
        }
    }
}
