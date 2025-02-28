using UnityEngine;
namespace EnivStudios.EnivInspector
{

    public class IfEnum : MonoBehaviour
    {
        private enum AnimalType { Cat, Dog, Rabbit, Parrot }
        [SerializeField] private AnimalType selectAnimal;

        [IfEnum("selectAnimal", (int)AnimalType.Cat)][SerializeField] private int catSpeed;
        [IfEnum("selectAnimal", (int)AnimalType.Dog)][SerializeField] private int dogSpeed;
        [IfEnum("selectAnimal", (int)AnimalType.Rabbit)][SerializeField] private int rabbitSpeed;
        [IfEnum("selectAnimal", (int)AnimalType.Parrot)][SerializeField] private int parrotSpeed;

        [IfEnum("selectAnimal", (int)AnimalType.Cat, (int)AnimalType.Dog, (int)AnimalType.Rabbit, (int)AnimalType.Parrot)][SerializeField] private int distance;
    }
}