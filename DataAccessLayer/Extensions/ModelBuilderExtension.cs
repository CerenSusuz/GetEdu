using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder MapConfiguration(this ModelBuilder mb)
        {
            return mb.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public static void SetDataType(this ModelBuilder mb)
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
                if (property.ClrType == typeof(decimal)) property.SetColumnType("decimal(18,4)");

                if (property.ClrType == typeof(double)) property.SetColumnType("money");

                if (property.ClrType == typeof(bool)) property.SetDefaultValue(false);

                if (property.ClrType == typeof(byte) || property.ClrType == typeof(short) || property.ClrType == typeof(int) || property.ClrType == typeof(float) ||
                    property.ClrType == typeof(double) || property.ClrType == typeof(decimal))
                {
                    if (!property.IsNullable && !property.IsPrimaryKey() && !property.IsForeignKey())
                        property.SetDefaultValue(0);
                }
                else if (property.ClrType == typeof(string))
                {
                    property.IsNullable = false;
                    property.SetDefaultValueSql("space(0)");
                }
                else if (property.ClrType == typeof(DateTime) && !property.IsNullable)
                {
                    property.SetDefaultValueSql("Convert(Date,GetDate())");
                }
                else if (property.ClrType == typeof(TimeSpan))
                {
                    property.SetDefaultValueSql("'00:00'");
                }
                else if (property.ClrType == typeof(Guid))
                {
                    property.SetDefaultValueSql("NewId()");
                }

                switch (property.Name)
                {
                    case "Gsm":
                        property.SetMaxLength(10);
                        break;


                    case "FirstName":
                    case "Name":
                    case "LastName":
                        property.SetMaxLength(50);
                        break;

                    case "CreatedAt":
                    case "UpdatedAt":
                        property.SetDefaultValueSql("GetDate()");
                        break;

                    case "Email":
                        property.SetMaxLength(75);
                        break;

                    case "Title":
                        property.SetMaxLength(100);
                        break;

                }
            }
        }
    }
}


