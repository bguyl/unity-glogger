﻿namespace Guyl.Logger
{
    using System;

    /// <summary>
    /// Logging severity levels
    /// </summary>
    /// <remarks>
    /// This type is compatible with <c><see cref="UnityEngine.LogType"/></c> and add new levels
    /// </remarks>
    public enum GLogType
    {
        // Values compatible with Unity LogType
        Error = 0,
        Assert = 1,
        Warning = 2,
        Log = 3,
        Exception = 4,
        
        // New values
        Information = 3, // Information is equivalent to Log
        Critical = 5,
        Debug = 6,
        Trace = 7,
        VeryVerbose = 8
    }

    /// <summary>
    /// Flags for filtering logging severity levels
    /// </summary>
    /// <remarks>
    /// This is mirroring <c><see cref="Guyl.Logger.GLogType"/></c>, but is useful for filtering levels
    /// </remarks>
    [Flags]
    public enum GLogTypeFlag
    {
        None = 0,
        Error = 1 << 0,
        Assert = 1 << 1,
        Warning = 1 << 2,
        Log = 1 << 3,
        Information = 1 << 3, // Information is equivalent to Log
        Exception = 1 << 4,
        Critical = 1 << 5,
        Debug = 1 << 6,
        Trace = 1 << 7,
        VeryVerbose = 1 << 8,
        All = ~0
    }
}