using UnityEngine;
using Photon.Pun;

public class EyeBlockCull : MonoBehaviourPunCallbacks
{
    [SerializeField] public string layerName = "Cull";
    public int layerIndex = 12;

    private void Start()
    {
        layerIndex = LayerMask.NameToLayer(layerName);

        if (photonView.IsMine)
        {
            gameObject.layer = layerIndex;
        }
    }
}
