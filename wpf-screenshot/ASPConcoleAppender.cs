using log4net.Appender;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace wpf_webview2
{
    public class ASPConcoleAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            System.Diagnostics.Debug.WriteLine(loggingEvent.Level.Name, loggingEvent.RenderedMessage);
        }
    }
}
