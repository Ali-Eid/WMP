using System;
namespace WMBProject.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "api";
        public const string version = "v1";
        public const string byId = "/{Id}";

        public const string rule = root + "/" + version + "/";

       public static class ArtistRouting
        {
            public const string prefix = rule + "artist";
            public const string list = prefix + "/list";
            public const string artistById = prefix + byId;
            public const string create = prefix + "/create";
            public const string update = prefix + "/update";
            public const string delete = prefix + "/delete"+byId;
        }
        public static class SongRouting
        {
            public const string prefix = rule + "song";
            public const string list = prefix + "/list";
            public const string songById = prefix + byId;
            public const string create = prefix + "/create";
            public const string update = prefix + "/update";
            public const string delete = prefix + "/delete" + byId;
        }
        public static class OrderRouting
        {
            public const string prefix = rule + "order";
            public const string list = prefix + "/list";
            public const string create = prefix + "/create";
        }
        public static class InvoiceRouting
        {
            public const string prefix = rule + "invoice";
            public const string create = prefix + "/create";
        }
        public static class CustomerRouting
        {
            public const string prefix = rule + "customer";
            public const string create = prefix + "/create";
            public const string login = prefix + "/login";

        }

    }
}

