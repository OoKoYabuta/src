using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TargetController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �J�����̉�]���擾
        Quaternion cameraRotation = Camera.main.transform.rotation;

        // �J�����̉�]��Euler�p�ɕϊ��i�K�v�Ȏ��̉�]���擾�j
        Vector3 eulerAngles = cameraRotation.eulerAngles;

        // Y���i�������j�̉�]�p�x���擾
        float yRotation = eulerAngles.y;

        // X���i�������j�̉�]�p�x���擾
        float xRotation = eulerAngles.x;

        // Y���̕␳�i0�x�܂���180�x�ɕ␳�j
        if (yRotation > 90f && yRotation < 270f)
        {
            // 0�x�ɕ␳
            yRotation = 0f;
        }
        else
        {
            // 180�x�ɕ␳
            yRotation = 180f;
        }

        // X���̕␳�i0�x�܂���180�x�ɕ␳�j
        if (xRotation > 90f && xRotation < 270f)
        {
            // 0�x�ɕ␳
            xRotation = 0f;
        }
        else
        {
            // 180�x�ɕ␳
            xRotation = 180f;
        }

        // X����Y����␳������]��K�p
        this.gameObject.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    public void OnMouseDown()
    {
        // Debug.Log(GameManager.instance.stageNo);
        Debug.Log("OnMouseDown");
        Instantiate(particle,transform.position,transform.rotation);
        Destroy(this.gameObject);
        GameManager.instance.gameScore += 10;
        AudioSe.instance.AudioPlay(0);
    }

}
