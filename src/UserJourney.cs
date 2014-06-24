using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Journey.Results;
using Journey.Tests;

namespace Journey
{
    public class UserJourney
    {
        private readonly ICollection<ITestable> _tests;

        public string Name { get; private set; }

        public List<ITestResult> Results { get; set; }

        public bool? Passed
        {
            get
            {
                if (HasFailure())
                {
                    return false;
                }

                if (IsPending())
                {
                    return null;
                }

                return true;
            }
        }

        public UserJourney()
        {
            _tests = new Collection<ITestable>();
        }

        public UserJourney(string name)
        {
            Name = name;
            _tests = new Collection<ITestable>();
        }

        public UserJourney For(string testName)
        {
            Name = testName;
            return this;
        }

        public UserJourney User(Action userAction)
        {
            AddTestStep(userAction, "User", userAction.Method);
            return this;
        }

        public UserJourney User<T>(Action<T> userAction, T arg1)
        {
            AddTestStep(() => userAction(arg1), "User", userAction.Method, arg1);
            return this;
        }

        public UserJourney User<T1, T2>(Action<T1, T2> userAction, T1 arg1, T2 arg2)
        {
            AddTestStep(() => userAction(arg1, arg2), "User", userAction.Method, arg1, arg2);
            return this;
        }

        public UserJourney User<T1, T2, T3>(Action<T1, T2, T3> userAction, T1 arg1, T2 arg2, T3 arg3)
        {
            AddTestStep(() => userAction(arg1, arg2, arg3), "User", userAction.Method, arg1, arg2, arg3);
            return this;
        }

        public UserJourney And(Action userAction)
        {
            AddTestStep(userAction, "And", userAction.Method);
            return this;
        }

        public UserJourney And<T>(Action<T> userAction, T arg)
        {
            AddTestStep(() => userAction(arg), "And", userAction.Method, arg);
            return this;
        }

        public UserJourney And<T1, T2>(Action<T1, T2> userAction, T1 arg1, T2 arg2)
        {
            AddTestStep(() => userAction(arg1, arg2), "And", userAction.Method, arg1, arg2);
            return this;
        }

        public UserJourney And<T1, T2, T3>(Action<T1, T2, T3> userAction, T1 arg1, T2 arg2, T3 arg3)
        {
            AddTestStep(() => userAction(arg1, arg2, arg3), "And", userAction.Method, arg1, arg2, arg3);
            return this;
        }

        public UserJourney Verify(Action verifyAction)
        {
            AddTestStep(verifyAction, "Verify", verifyAction.Method);
            return this;
        }

        public UserJourney Verify<T>(Action<T> verifyAction, T arg1)
        {
            AddTestStep(() => verifyAction(arg1), "Verify", verifyAction.Method, arg1);
            return this;
        }

        public UserJourney Verify<T1, T2>(Action<T1, T2> verifyAction, T1 arg1, T2 arg2)
        {
            AddTestStep(() => verifyAction(arg1, arg2), "Verify", verifyAction.Method, arg1, arg2);
            return this;
        }

        public UserJourney Verify<T1, T2, T3>(Action<T1, T2, T3> verifyAction, T1 arg1, T2 arg2, T3 arg3)
        {
            AddTestStep(() => verifyAction(arg1, arg2, arg3), "Verify", verifyAction.Method, arg1, arg2, arg3);
            return this;
        }

        public void Run()
        {
            Console.WriteLine("Running Test: {0}", Name);
            var testResults = _tests.Select(test => test.Execute()).ToList();
            Results = testResults;

            foreach (var testResult in testResults)
            {
                Console.WriteLine("{0}: {1}", testResult.TestName, testResult.Message);
            }

            FailIfErrorsExist(testResults);
        }

        private static void FailIfErrorsExist(IList<ITestResult> testResults)
        {
            const string separator = "\n-----------------------------------------------------\n";
            if (testResults.Any(r => r.WasSuccess.HasValue && !r.WasSuccess.Value))
            {
                var errors = testResults.Where(r => r.WasSuccess.HasValue && !r.WasSuccess.Value);
                var errorCount = errors.Count();
                Assert.Fail("{0} test(s) failed.\n {1}", errorCount, string.Join(separator, errors.Select(err => err.DetailedMessage)));
            }
        }

        private void AddTestStep(Action action, string actionType, MethodInfo method, params object[] args)
        {
            var argList = string.Join(",", args);

            var testName = string.Format("{0} {1} {2}", actionType, method.Name.UnCamel(), argList);
            _tests.Add(new TestStep(action, testName));
        }

        private bool HasFailure()
        {
            return Results.Any(x => x.WasSuccess.HasValue && !x.WasSuccess.Value);
        }

        private bool IsPending()
        {
            return Results.Any(x => !x.WasSuccess.HasValue);
        }
    }
}


