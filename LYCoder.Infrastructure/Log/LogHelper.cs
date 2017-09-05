﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using System.ComponentModel;
using System.Threading;

namespace LYCoder.Common
{
    /// <summary>
    /// NLog日志框架辅助类。
    /// </summary>
    public static class LogHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 注册日志配置文件。
        /// </summary>
        public static void RegisterConfig()
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + @"\Configs\NLog.config";
            LogManager.Configuration = new XmlLoggingConfiguration(configPath);
        }
        /// <summary>
        /// 记录日志。
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <param name="operation">动作</param>
        /// <param name="message">消息</param>
        /// <param name="account">操作者</param>
        /// <param name="realName">真实姓名</param>
        public static void Write(Level level, string operation, string message, int account, string realName)
        {
            ThreadPool.QueueUserWorkItem(t =>
            { WriteLog(level, operation, message, account, realName); });
        }

        /// <summary>
        /// 记录日志。
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <param name="operation">动作</param>
        /// <param name="message">消息</param>
        /// <param name="account">操作者</param>
        /// <param name="realName">真实姓名</param>
        public static void WriteLog(Level level, string operation, string message, int account, string realName)
        {
            LogEventInfo logEvent = new LogEventInfo();
            logEvent.Message = message;
            switch (level)
            {
                case Level.Trace:
                    logEvent.Level = LogLevel.Trace;
                    break;
                case Level.Debug:
                    logEvent.Level = LogLevel.Debug;
                    break;
                case Level.Info:
                    logEvent.Level = LogLevel.Info;
                    break;
                case Level.Warn:
                    logEvent.Level = LogLevel.Warn;
                    break;
                case Level.Error:
                    logEvent.Level = LogLevel.Error;
                    break;
                case Level.Fatal:
                    logEvent.Level = LogLevel.Fatal;
                    break;
            }
            string ip = Net.Ip;
            logEvent.Properties["Account"] = account;
            logEvent.Properties["RealName"] = realName;
            logEvent.Properties["Operation"] = operation;
            logEvent.Properties["IP"] = ip;
            logEvent.Properties["IPAddress"] = Net.GetAddress(ip);
            logEvent.Properties["Browser"] = Net.Browser;
            logger.Log(logEvent);
        }

        /// <summary>
        /// 最常见的记录信息，一般用于普通输出。
        /// </summary>
        /// <param name="message"></param>
        public static void Trace(string message)
        {
            ThreadPool.QueueUserWorkItem(t =>
            { logger.Trace(message); });
        }

        /// <summary>
        /// 同样是记录信息，不过出现的频率要比Trace少一些，一般用来调试程序。
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            ThreadPool.QueueUserWorkItem(t =>
            { logger.Debug(message); });
        }

        /// <summary>
        /// 信息类型的消息。
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            ThreadPool.QueueUserWorkItem(t =>
            { logger.Info(message); });
        }

        /// <summary>
        /// 警告信息，一般用于比较重要的场合。
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            ThreadPool.QueueUserWorkItem(t =>
            { logger.Warn(message); });
        }

        /// <summary>
        /// 错误信息。
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            var current = OperatorProvider.Instance.Current;
            Write(Level.Error, "程序异常", message, current == null ? 0 : current.UserId, current == null ? "未知用户" : current.RealName);
        }

        /// <summary>
        /// 致命异常信息。一般来讲，发生致命异常之后程序将无法继续执行。
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(string message)
        {
            ThreadPool.QueueUserWorkItem(t =>
            { logger.Fatal(message); });
        }
    }

    public enum Level
    {
        [Description("普通输出")]
        Trace,
        [Description("一般调试")]
        Debug,
        [Description("普通消息")]
        Info,
        [Description("警告信息")]
        Warn,
        [Description("一般错误")]
        Error,
        [Description("致命错误")]
        Fatal
    }

}
