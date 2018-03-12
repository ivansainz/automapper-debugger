using System.Collections.Generic;
using System.Linq.Expressions;
using AgileObjects.ReadableExpressions;
using AutoMapper;

namespace automapperdebugger
{
    public class Debugger<TOrigin, TDestination>
    {
        private readonly TOrigin _origin;

        /// <summary>
        /// Initializes a Debugger instance getting the origin object to map from
        /// </summary>
        public Debugger()
        {
            _origin = new DebuggerTestObjects<TOrigin>().GetTestObject();
        }

        /// <summary>
        /// Maps the origin's object to a destination object for testing purposes. You must configure your origin object in DebuggerTestObjects.
        /// </summary>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public TDestination TestMapping(IMapper mapper)
        {
            return mapper.Map<TDestination>(_origin);
        }

        /// <summary>
        /// Gets the execution plan for the mapping from TOrigin to TDestination
        /// </summary>
        /// <typeparam name="TOrigin">Original type in the mapping</typeparam>
        /// <typeparam name="TDestination">Destination type in the mapping</typeparam>
        /// <param name="mapper">The IMapper instance whose configuration is being debugged</param>
        /// <returns>Lambda expression with the execution plan that is loaded in memory</returns>
        public static LambdaExpression GetBuildExecutionPlan<TOrigin, TDestination>(IMapper mapper)
        {
            return mapper.ConfigurationProvider.BuildExecutionPlan(typeof(TOrigin), typeof(TDestination));
        }

        /// <summary>
        /// Gets the execution plan for the mapping from TOrigin to TDestination as a string
        /// </summary>
        /// <typeparam name="TOrigin">Original type in the mapping</typeparam>
        /// <typeparam name="TDestination">Destination type in the mapping</typeparam>
        /// <param name="mapper">The IMapper instance whose configuration is being debugged</param>
        /// <returns>Lambda expression with the execution plan that is loaded in memory converted to a string</returns>
        public static string GetBuildExecutionPlanAsString<TOrigin, TDestination>(IMapper mapper)
        {
            return GetBuildExecutionPlan<TOrigin, TDestination>(mapper).ToReadableString();
        }

        /// <summary>
        /// Gets all configured type maps created
        /// </summary>
        /// <param name="mapper">The IMapper instance whose configuration is being debugged</param>
        /// <returns>Array of type maps</returns>
        public static TypeMap[] GetAllMappedTypes(IMapper mapper)
        {
            return mapper.ConfigurationProvider.GetAllTypeMaps();
        }

        /// <summary>
        /// Get all configured mappers
        /// </summary>
        /// <param name="mapper">The IMapper instance whose configuration is being debugged</param>
        /// <returns>Enumerable of IObjectMappers</returns>
        public static IEnumerable<IObjectMapper> GetAllMappers(IMapper mapper)
        {
            return mapper.ConfigurationProvider.GetMappers();
        }
    }
}
