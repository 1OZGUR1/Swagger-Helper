namespace SwaggerHelperApp.VersioningTool.SwaggerServiceHelpers;

public class SwaggerOperationFilter : IOperationFilter
{
    private readonly EndpointTypeHelper _filterType;

    public SwaggerOperationFilter(EndpointTypeHelper filterType)
    {
        _filterType = filterType;
    }

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (_filterType == EndpointTypeHelper.All)
            return;

        var method = context.ApiDescription.HttpMethod;

        switch (_filterType)
        {
            case EndpointTypeHelper.Get:
                if (method != "GET")
                    operation.Tags.Clear();
                break;
            case EndpointTypeHelper.Post:
                if (method != "POST")
                    operation.Tags.Clear();
                break;
            case EndpointTypeHelper.Put:
                if (method != "PUT")
                    operation.Tags.Clear();
                break;
            case EndpointTypeHelper.Delete:
                if (method != "DELETE")
                    operation.Tags.Clear();
                break;
            case EndpointTypeHelper.Command:
                if (!context.ApiDescription.ActionDescriptor.DisplayName.Contains("Command"))
                    operation.Tags.Clear();
                break;
            case EndpointTypeHelper.Query:
                if (!context.ApiDescription.ActionDescriptor.DisplayName.Contains("Query"))
                    operation.Tags.Clear();
                break;
            default:
                break;
        }
    }
}