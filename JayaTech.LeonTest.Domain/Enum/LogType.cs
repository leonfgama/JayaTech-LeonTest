using System;
using System.Collections.Generic;
using System.Text;

namespace JayaTech.LeonTest.Domain.Enum
{
    public enum LogType
    {
        LoginSuccess = 1,
        LoginFailed = 2,
        TransactionSuccess = 3,
        TransactionFailed = 4,
        ExchangeApiCallDuration = 5,
        Exception = 6,
        ApiCall = 7,
        ApiCallError = 8
    }

    public class LogTypeHelper
    {
        public static string GetLogTypeTitle(int type)
        {
            return LogTypeHelper.GetLogTypeTitle((LogType)type);
        }

        public static string GetLogTypeTitle(LogType type)
        {
            switch (type)
            {
                case LogType.LoginSuccess:
                    return "Login Success";
                case LogType.LoginFailed:
                    return "Login Failed";
                case LogType.TransactionSuccess:
                    return "Transaction Success";
                case LogType.TransactionFailed:
                    return "Transaction Failed!";
                case LogType.ExchangeApiCallDuration:
                    return "Exchange External API Duration";
                case LogType.Exception:
                    return "Exception";
                case LogType.ApiCall:
                    return "API Call";
                case LogType.ApiCallError:
                    return "API Error";
                default:
                    return "Uncataloged Type";
            }
        }

    }
}