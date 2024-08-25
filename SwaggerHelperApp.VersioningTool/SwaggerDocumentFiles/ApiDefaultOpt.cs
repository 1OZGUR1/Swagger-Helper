namespace SwaggerHelperApp.VersioningTool.SwaggerDocumentFiles;

public class ApiDefaultOpt
{
    public bool IsAddAnnatationSupport { get; set; }
    public bool IsAddXmlDocSupport { get; set; }
    public bool IsAddSwaggerJwtSecuritySupport { get; set; }
    public bool IsAddSwaggerSecuritySupport { get; set; }


    public class Builder
    {
        private ApiDefaultOpt _iApiDefaultOpt;

        public Builder()
        {
            _iApiDefaultOpt ??= new ApiDefaultOpt();
        }

        public Builder AddAnnatationSupport(bool b)
        {
            _iApiDefaultOpt.IsAddAnnatationSupport = b;
            return this;
        }

        public Builder AddXmlDocSupport(bool b)
        {
            _iApiDefaultOpt.IsAddXmlDocSupport = b;
            return this;
        }

        public Builder AddSwaggerJwtSecuritySupport(bool b)
        {
            _iApiDefaultOpt.IsAddSwaggerJwtSecuritySupport = b;
            return this;
        }

        public Builder AddSwaggerSecuritySupport(bool b)
        {
            _iApiDefaultOpt.IsAddSwaggerSecuritySupport = b;
            return this;
        }

        //public Builder AddExceptionMiddlewareEnabled(bool b)
        //{
        //    _iApiDefaultOpt.IsExceptionMiddlewareEnabled = b;
        //    return this;
        //}

        public ApiDefaultOpt Build()
        {
            return _iApiDefaultOpt;
        }
    }
}