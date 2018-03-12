using System.Collections.Generic;
using System.Linq;

namespace automapperdebugger
{
    /// <summary>
    /// Contains a list of objects to be tested
    /// </summary>
    /// <typeparam name="T">Type of the origin object to be tested</typeparam>
    public class DebuggerTestObjects<T>
    {
        readonly List<object> _testObjectsList = new List<object>();

        /// <summary>
        /// Creates a list of testing objects with the appropriate properties set.
        /// </summary>
        public DebuggerTestObjects()
        {
            /*
             Add all testing objects here with the desired property values. Add only one object per type.
             NOTE: Replace these with yours
             */

            _testObjectsList.Add(new Example1
            {
                Property1 = 1,
                Property2 = "some text"
            });

            _testObjectsList.Add(new Example2
            {
                Id = 77,
                Example1 = new Example1
                {
                    Property1 = 1,
                    Property2 = "more text"
                }
            });
        }

        /// <summary>
        /// Gets and instance of the object to be tested. If there is more than one instance of the object in the list, an exception will be thrown.
        /// </summary>
        /// <returns>Instance of the object to be tested</returns>
        public T GetTestObject()
        {
            return (T) _testObjectsList.Single(o => o.GetType() == typeof(T));
        }
    }
}
