using UnityEngine;
using YG;

public class SavePoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { gameObject.GetComponentInChildren<ParticleSystem>().Stop(); }
        YandexGame.savesData.savePosition = new Vector3(other.transform.position.x, other.transform.position.y+1, other.transform.position.z);
        YandexGame.SaveProgress();
    }
}
