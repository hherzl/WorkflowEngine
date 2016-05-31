namespace WorkflowEngine.Common
{
    public static class Mapper
    {
        public static TTarget Map<TSource, TTarget>(this TSource source) where TTarget : new()
        {
            var value = default(TTarget);

            var sourceType = typeof(TSource);
            var targetType = typeof(TTarget);

            foreach (var sourceProperty in sourceType.GetProperties())
            {
                if (sourceProperty.CanRead)
                {
                    foreach (var targetProperty in targetType.GetProperties())
                    {
                        if (targetProperty.CanWrite)
                        {
                            if (value == null)
                            {
                                value = new TTarget();
                            }

                            if (sourceProperty.Name == targetProperty.Name)
                            {
                                if (sourceProperty.PropertyType.FullName == targetProperty.PropertyType.FullName)
                                {
                                    targetProperty.SetValue(value, sourceProperty.GetValue(source));
                                }
                            }
                        }
                    }
                }
            }

            return value;
        }
    }
}
