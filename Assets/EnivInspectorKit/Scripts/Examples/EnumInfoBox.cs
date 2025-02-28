
using UnityEngine;

namespace EnivStudios.EnivInspector
{
    public class EnumInfoBox : MonoBehaviour
    {
        private enum GameType { FPS, TPS, Racing, Arcade }
        [SerializeField] private GameType selectType;

        [EnumInfoBox("LOTUS GTR has average milege", spaceAbove: 2, spaceBelow: 0, MessageType.Info, "selectType", (int)GameType.Racing)]
        [SerializeField] private int carSpeed;

        [EnumInfoBox("Write anything here :)", spaceAbove: 2, spaceBelow: 0, MessageType.Info, "selectType", (int)GameType.FPS)]
        [SerializeField] private Transform fpsCam;
    }
}