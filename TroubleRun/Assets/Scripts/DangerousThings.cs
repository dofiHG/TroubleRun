using UnityEngine;
using YG;

public class DangerousThings : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { other.transform.position = YandexGame.savesData.savePosition; }
    }
}
