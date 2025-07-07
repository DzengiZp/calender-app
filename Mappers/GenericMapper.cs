namespace precio_summer_project.Mappers;

public class GenericMapper<TFinalObject>
    where TFinalObject : new()
{
    public static TFinalObject Map<TStartObject>(TStartObject startObject)
    {
        if (startObject == null)
            throw new ArgumentNullException(nameof(startObject), "Generic object can't be empty");

        var finalObject = new TFinalObject();
        var finalObjectType = typeof(TFinalObject);
        var startObjectType = typeof(TStartObject);

        var finalObjectProperties = finalObjectType.GetProperties().Where(p => p.CanWrite);
        var startObjectProperties = startObjectType.GetProperties().Where(p => p.CanRead);

        foreach (var prop in finalObjectProperties)
        {
            var startProp = startObjectProperties.FirstOrDefault(p =>
                p.Name == prop.Name && p.PropertyType == prop.PropertyType
            );

            if (startProp != null)
            {
                var value = startProp.GetValue(startObject);
                prop.SetValue(finalObject, value);
            }
        }

        return finalObject;
    }
}
