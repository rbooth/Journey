using System;
using System.Collections.Generic;
using System.IO;
using RazorEngine;

namespace Journey.Core.Reporting
{
    public class JourneyRunner
    {
        private static readonly Lazy<JourneyRunner> Lazy = new Lazy<JourneyRunner>(() => new JourneyRunner());

        public static JourneyRunner Current
        {
            get { return Lazy.Value; }
        }

        private JourneyRunner()
        {
            Tests = new List<UserJourney>();
        }

        public IList<UserJourney> Tests { get; set; }

        public void RunReport()
        {
            var sr = new StreamReader(@"content\results.tmpl");

            var result = Razor.Parse(sr.ReadToEnd(),Tests);

            File.WriteAllText(@"acceptanceTestResults.html", result);
        }
    }
}