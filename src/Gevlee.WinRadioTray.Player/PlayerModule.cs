using Autofac;

namespace Gevlee.WinRadioTray.Player
{
	public class PlayerModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<PlayerService>().AsImplementedInterfaces().SingleInstance();
		}
	}
}