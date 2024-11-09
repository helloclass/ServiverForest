using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryFlameThrowerController : Buki
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isThrowHold = true;
        }

        if (isThrowHold)
        {
            GameObject ThrowObject = Instantiate(HandleThrowBody, HandleThrowBody.transform);
            ThrowObject.SetActive(true);
            ThrowObject.transform.parent = null;

            ThrowObject.GetComponent<MilitaryFlare>().Fire(transform.forward);
        }
    }

    // ȭ��, �Ѿ� ���� �Ҹ�ǰ���� ���� �� ����Ͽ�����
    public override void ThrowObjectIsEmpty()
    {
        HandPlayer.GetComponent<PlayerController>().ThrowedHandleObject();
    }

    // ȭ��, �Ѿ� ���� �Ҹ�ǰ���� �������� ��
    public override void ChargingThrowObject()
    {

    }

    public override IEnumerator CalcNextClip()
    {
        yield return new WaitForSeconds(0.1f);
    }
    public override IEnumerator UpdateAnimator()
    {
        while (true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                isThrowHold = false;
            }

            yield return null;
        }
    }
}
