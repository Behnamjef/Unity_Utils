using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicOwl.Utils
{
    public static class Logger
    {
        private static Dictionary<string, DateTime> _timesDictionary = new();

        public static void Log(
            object log, 
            LogColor color = LogColor.White, 
            LogStyle style = LogStyle.Normal, 
            int size = 12)
        {
            switch (style)
            {
                case LogStyle.Bold:
                    log = log.ToString().Bold();
                    break;
                case LogStyle.Italic:
                    log = log.ToString().Italic();
                    break;
                case LogStyle.Normal:
                default:
                    break;
            }

            Debug.Log(($"<><> {log}").Color(color).Size(size));
        }

        public static void LogError(string log)
        {
            Debug.LogError($"<><> Error!\t{log}");
        }

        public static void SetTime(string name)
        {
            Log($"Task starts: {name}", LogColor.Orange);
            if (_timesDictionary.ContainsKey(name))
            {
                _timesDictionary[name] = DateTime.Now;
                return;
            }

            _timesDictionary.Add(name, DateTime.Now);
        }

        public static void ShowTimeDifference(string name)
        {
            if (!_timesDictionary.ContainsKey(name))
            {
                LogError($"{name} is not set before!");
                return;
            }

            Log($"Task finished: {name} - Time {(DateTime.Now - _timesDictionary[name]).TotalSeconds}", LogColor.Green);
        }

        private static string Bold(this string str) => "<b>" + str + "</b>";
        private static string Color(this string str, LogColor clr) => $"<color={clr}>{str}</color>";
        private static string Italic(this string str) => "<i>" + str + "</i>";
        private static string Size(this string str, int size) => $"<size={size}>{str}</size>";
    }

    public enum LogColor
    {
        Red,
        Yellow,
        Blue,
        Orange,
        Black,
        White,
        Green
    }

    public enum LogStyle
    {
        Normal,
        Bold,
        Italic
    }
}