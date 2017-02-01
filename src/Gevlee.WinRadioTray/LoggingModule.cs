﻿using System;
using System.Linq;
using System.Reflection;
using Autofac.Core;
using Module = Autofac.Module;

namespace Gevlee.WinRadioTray
{
	public class LoggingModule<TLog> : Module
	{
		private Func<Type, TLog> getLoggerFunc;

		public LoggingModule(Func<Type, TLog> getLoggerFunc)
		{
			this.getLoggerFunc = getLoggerFunc;
		}

		private void InjectLoggerProperties(object instance)
		{
			var instanceType = instance.GetType();

			// Get all the injectable properties to set.
			// If you wanted to ensure the properties were only UNSET properties,
			// here's where you'd do it.
			var properties = instanceType
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(p => p.PropertyType == typeof(TLog) && p.CanWrite && p.GetIndexParameters().Length == 0);

			// Set the properties located.
			foreach (var propToSet in properties)
			{
				propToSet.SetValue(instance, getLoggerFunc(instanceType), null);
			}
		}

		private void OnComponentPreparing(object sender, PreparingEventArgs e)
		{
			e.Parameters = e.Parameters.Union(
				new[]
				{
					new ResolvedParameter(
						(p, i) => p.ParameterType == typeof(TLog),
						(p, i) => getLoggerFunc(p.Member.DeclaringType)
					),
				});
		}

		protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry,
			IComponentRegistration registration)
		{
			// Handle constructor parameters.
			registration.Preparing += OnComponentPreparing;

			// Handle properties.
			registration.Activated += (sender, e) => InjectLoggerProperties(e.Instance);
		}
	}
}