using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace SampleGame
{
    public class LocationSpawnTrigger:MonoBehaviour
    {
        [FormerlySerializedAs("id")]
        [SerializeField]
        private string locationID;

        [SerializeField]
        private Transform parentTransform;
        
        private LocationSpawnManager _locationSpawnManager;

        [Inject]
        public void Construct(LocationSpawnManager locationSpawnManager)
        {
            _locationSpawnManager = locationSpawnManager;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
                _locationSpawnManager.LoadLocation(locationID,parentTransform);
                
        }
    }
}