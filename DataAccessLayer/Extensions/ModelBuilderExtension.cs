using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SetDataType(ModelBuilder mb)
        {
            var mBuilders = mb.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(x => !x.IsOwnership && x.DeleteBehavior == DeleteBehavior.Cascade).ToList();

            foreach (var fk in mBuilders)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            var properties = mb.Model.GetEntityTypes().SelectMany(t => t.GetProperties().OrderBy(x => x.Name));
            foreach (var property in properties)
            {
                switch (property.Name)
                {
                    case "Gsm":
                        property.SetMaxLength(10);
                        break;

                    case "FirstName":
                    case "LastName":
                        property.SetMaxLength(30);
                        break;

                    case "CreatedUser":
                    case "UpdatedUser":
                        property.SetMaxLength(61);
                        break;

                        //TODO:ef6
                    //case "CreatedAt":
                    //case "UpdatedAt":
                    //    property.HasDefaultValueSql("getdate()");
                    //    break;

                    case "Email":
                        property.SetMaxLength(75);
                        break;
                    case "Description":
                    case "Title":
                    case "Url":
                        property.SetMaxLength(100);
                        break;
                }
            }
        }
    }
}

