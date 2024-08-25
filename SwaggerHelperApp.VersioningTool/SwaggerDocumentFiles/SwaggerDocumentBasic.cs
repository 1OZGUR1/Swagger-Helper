namespace SwaggerHelperApp.VersioningTool.SwaggerDocumentFiles;

public class SwaggerDocumentBasic
{
    public string? Version { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ContactName { get; set; }
    public string? ContactEmail { get; set; }
    public string? LicenseName { get; set; }
    public string? LicenseUrl { get; set; }
    public string? TermsOfServiceUrl { get; set; }

    public class Builder
    {
        private SwaggerDocumentBasic _doc;

        public Builder()
        {
            _doc ??= new SwaggerDocumentBasic();
        }


        public Builder SetVersion(string value)
        {
            _doc.Version = value;
            return this;
        }

        public Builder SetTitle(string value)
        {
            _doc.Title = value;
            return this;
        }

        public Builder SetDescription(string value)
        {
            _doc.Description = value;
            return this;
        }

        public Builder SetContactName(string value)
        {
            _doc.ContactName = value;
            return this;
        }

        public Builder SetContactEmail(string value)
        {
            _doc.ContactEmail = value;
            return this;
        }

        public Builder SetLicenseName(string value)
        {
            _doc.LicenseName = value;
            return this;
        }

        public Builder SetLicenseUrl(string value)
        {
            _doc.LicenseUrl = value;
            return this;
        }

        public Builder SetTermsOfServiceUrl(string value)
        {
            _doc.TermsOfServiceUrl = value;
            return this;
        }

        public SwaggerDocumentBasic Build()
        {
            return _doc;
        }
    }
}