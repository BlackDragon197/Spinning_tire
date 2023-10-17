using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignButton : MonoBehaviour
{
    public void OnSelectCampaign()
    {
        UIManager.Instance.SelectCampaign();
    }
    
}
