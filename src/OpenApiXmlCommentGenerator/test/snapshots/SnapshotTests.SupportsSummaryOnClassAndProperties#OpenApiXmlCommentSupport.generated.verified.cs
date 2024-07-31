﻿//HintName: OpenApiXmlCommentSupport.generated.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable

namespace System.Runtime.CompilerServices
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.AspNetCore.OpenApi.SourceGenerators, Version=42.42.42.42, Culture=neutral, PublicKeyToken=adb9793829ddae60", "42.42.42.42")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    file sealed class InterceptsLocationAttribute : System.Attribute
    {
        public InterceptsLocationAttribute(int version, string data)
        {
        }
    }
}

namespace Microsoft.AspNetCore.OpenApi.Generated
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.OpenApi;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Any;

    file class XmlComment
    {
        public string? Summary { get; }
        public object? Example { get; }

        public XmlComment(string? summary, object? example)
        {
            Summary = summary;
            Example = example;
        }
    }

    file static class OpenApiAnyExtensions
    {
        public static IOpenApiAny ToOpenApiAny(this object? value)
        {
            if (value is null)
            {
                return new OpenApiNull();
            }
            if (value is bool boolValue)
            {
                return new OpenApiBoolean(boolValue);
            }
            if (value is int intValue)
            {
                return new OpenApiInteger(intValue);
            }
            if (value is long longValue)
            {
                return new OpenApiLong(longValue);
            }
            if (value is float floatValue)
            {
                return new OpenApiFloat(floatValue);
            }
            if (value is double doubleValue)
            {
                return new OpenApiDouble(doubleValue);
            }
            if (value is string stringValue)
            {
                return new OpenApiString(stringValue);
            }
            if (value is byte[] byteArrayValue)
            {
                return new OpenApiBinary(byteArrayValue);
            }
            if (value is System.DateTime dateTimeValue)
            {
                return new OpenApiDateTime(dateTimeValue);
            }
            if (value is System.DateTimeOffset dateTimeOffsetValue)
            {
                return new OpenApiDateTime(dateTimeOffsetValue);
            }
            if (value is System.Uri uriValue)
            {
                return new OpenApiString(uriValue.ToString());
            }
            if (value is System.Collections.IEnumerable enumerableValue)
            {
                var array = new OpenApiArray();
                foreach (var item in enumerableValue)
                {
                    array.Add(item.ToOpenApiAny());
                }
                return array;
            }
            return new OpenApiString(value.ToString());
        }
    }

    file class XmlCommentTransformer : IOpenApiDocumentTransformer
    {
        internal static readonly Dictionary<(Type, string?), XmlComment> Cache = new()
        {
            { (typeof(global::Todo), null), new XmlComment("This is a todo item.", null) },
            { (typeof(global::Todo), System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName("Id")), new XmlComment("The ID of the todo item.", null) },
            { (typeof(global::Todo), System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName("Name")), new XmlComment("The name of the todo item.", null) },
            { (typeof(global::Todo), System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName("Description")), new XmlComment("The description of the todo item.", null) },

        };

        public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public static Task XmlCommentOperationTransformer(OpenApiOperation operation, OpenApiOperationTransformerContext context, CancellationToken cancellationToken)
        {
            var methodInfo = context.Description.ActionDescriptor.EndpointMetadata.OfType<MethodInfo>().FirstOrDefault();
            if (Cache.TryGetValue((methodInfo.DeclaringType, methodInfo.Name), out var comment))
            {
                operation.Summary = comment.Summary;
            }
            return Task.CompletedTask;
        }

        public static Task XmlCommentSchemaTransformer(OpenApiSchema schema, OpenApiSchemaTransformerContext context, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debugger.Break();
            if (Cache.TryGetValue((context.Type, null), out var typeComment))
            {
                schema.Description = typeComment.Summary;
                if (typeComment.Example is not null)
                {
                    schema.Example = typeComment.Example.ToOpenApiAny();
                }
            }
            foreach (var property in schema.Properties)
            {
                if (Cache.TryGetValue((context.Type, property.Key), out var propertyComment))
                {
                    property.Value.Description = propertyComment.Summary;
                    if (propertyComment.Example is not null)
                    {
                        property.Value.Example = propertyComment.Example.ToOpenApiAny();
                    }
                }
            }
            return Task.CompletedTask;
        }
    }

    file static class GeneratedServiceCollectionExtensions
    {
        [global::System.Runtime.CompilerServices.InterceptsLocationAttribute(1, "pidK4Hn0tEglhkEOUrEJ/ZoAAABQcm9ncmFtLmNz")]
        public static IServiceCollection AddOpenApi(this IServiceCollection services)
        {
            return services.AddOpenApi("v1", options =>
            {
                options.UseTransformer(new XmlCommentTransformer());
                options.UseSchemaTransformer(XmlCommentTransformer.XmlCommentSchemaTransformer);
            });
        }

    }
}