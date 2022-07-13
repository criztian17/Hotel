using System.Collections.Generic;

namespace Hotel.Common.Helpers
{
    public static class ComparisonHelper<T, C>
        where T : class
        where C : class
    {
        /// <summary>
        /// Get a list of differences from the 2 models.
        /// Both models must be of the same class, if not it will return null
        /// </summary>
        /// <param name="currentModel">Current model of the class</param>
        /// <param name="newModel">New model of the class to be compared with the current</param>
        /// <returns>Collection of T</returns>
        public static Dictionary<string, string> GetListOfDifferences(T currentModel, C newModel)
        {
            Dictionary<string, string> differences = new Dictionary<string, string>();

            //Check if the models are of the same class
            if (currentModel.GetType().FullName != newModel.GetType().FullName)
                return null;

            foreach (var property in currentModel.GetType().GetProperties())
            {
                var currentValue = property.GetValue(currentModel);
                var newValue = property.GetValue(newModel);

                if (currentValue != null && newValue != null)
                    if (!currentValue.Equals(newValue))
                        differences.Add(property.Name, newValue.ToString());
            }

            return differences;
        }
    }
}
