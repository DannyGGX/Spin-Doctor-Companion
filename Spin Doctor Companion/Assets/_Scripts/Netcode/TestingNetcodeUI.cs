using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.Serialization;


namespace SpinDoctorCompanion
{
	
	public class TestingNetcodeUI : MonoBehaviour
	{
		[SerializeField] Button startHostButton;
		[SerializeField] Button startClientButton;

		private void Start()
		{
			
			startHostButton.onClick.AddListener(StartHost);
			startClientButton.onClick.AddListener(StartClient);
		}
		private void StartHost()
		{
			NetworkManager.Singleton.StartHost();
			Hide();
		}

		private void StartClient()
		{
			NetworkManager.Singleton.StartClient();
			Hide();
		}

		private void Hide()
		{
			gameObject.SetActive(false);
		}

	}
}
