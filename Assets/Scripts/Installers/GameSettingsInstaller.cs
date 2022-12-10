using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = nameof(GameSettingsInstaller), menuName = "Installers/" + nameof(GameSettingsInstaller))]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
	public override void InstallBindings()
	{
	}
}
