﻿namespace Spekt.Vstest.Coverage.Report
{
    using System;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    public class CLIReportTask : Task, ICancelableTask
    {
        private Trace trace;

        public CLIReportTask() : this(new Trace())
        {
        }

        [Required]
        public string TraceDataCollectorDirectoryPath
        {
            get;
            set;
        }

        public CLIReportTask(Trace trace)
        {
            this.trace = trace;
        }

        public override bool Execute()
        {
            //this.trace.Log("=================================================" + Environment.NewLine +
            //               "|   Module                     |  Coverage      |" + Environment.NewLine +
            //               "=================================================" + Environment.NewLine +
            //               "| Spekt.Vstest.Coverage.Report |  99.99%        |" + Environment.NewLine +
            //               "=================================================");
            Environment.SetEnvironmentVariable("Spekt_TraceDataCollectorDirectoryPath", TraceDataCollectorDirectoryPath);

            return true;
        }

        public void Cancel()
        {
            this.trace.Log("Cancel CLIReportTask...");
        }
    }
}