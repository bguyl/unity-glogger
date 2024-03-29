﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Guyl.Logger
{
	/// <summary>
	/// Log handler that logs messages to a file on Editor and Standalone platforms
	/// </summary>
	public class FileLogHandler : IGLogHandler
	{
		public string[] ChannelsIncludeFilters { get; }
		public string[] ChannelsExcludeFilters { get; }
		public GLogTypeFlag AllowedLogTypes { get; set; }
		public List<IGLogFormatter> LogFormatters { get; } = new List<IGLogFormatter>();
		public bool LogEnabled { get; set; }
		private IGLogHandler IGLogHandlerInterface => this;

		private readonly string _filename;

		public FileLogHandler(string filename, IGLogFormatter[] logFormatters = null)
		{
			_filename = filename;

			if (logFormatters != null)
			{
				LogFormatters.AddRange(logFormatters);	
			}
		}

		public FileLogHandler AppendFormatter(IGLogFormatter formatter)
		{
			LogFormatters.Add(formatter);
			return this;
		}
		
		public FileLogHandler PrependFormatter(IGLogFormatter formatter)
		{
			LogFormatters.Insert(0, formatter);
			return this;
		}
		
		public void LogFormat( LogType logType, Object context, string format, params object[] args )
		{
			if (!IGLogHandlerInterface.IsLogAllowed(K.DefaultChan, Convert.ToGLogType( logType ))) return;
			//
			// string message = format;
			// for (int i = 0; i < LogFormatters.Count; i++)
			// {
			// 	IGLogFormatter formatter = LogFormatters[i];
			// 	message = formatter.Format(logType, channel, context, format, caller, args);
			// }
		}

		public void LogException( Exception exception, Object context )
		{
			
		}

		public void LogFormat( GLogType logType, string channel, Object context, string format, object caller, LogOption logOptions,
			params object[] args )
		{
			if (!IGLogHandlerInterface.IsLogAllowed(channel, logType)) return;
			
			string message = format;
			for (int i = 0; i < LogFormatters.Count; i++)
			{
				IGLogFormatter formatter = LogFormatters[i];
				message = formatter.Format(logType, channel, context, format, caller, args);
			}
		}
	}
}