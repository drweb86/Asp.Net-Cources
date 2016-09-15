using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SK.DDP.ImageGallery.Helpers
{
    public static class WebModelExtensions
    {
        public static string GetDisplayName<TModel, TProperty>(
          this HtmlHelper<TModel> html, 
          Expression<Func<TModel, TProperty>> expression)
        {
            // Taken from LabelExtensions
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            
            string displayName = metadata.DisplayName;
            if (displayName == null)
            {
                string propertyName = metadata.PropertyName;
                if (propertyName == null)
                {
                    var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
                    displayName = ((IEnumerable<string>) htmlFieldName.Split('.')).Last<string>();
                }
                else
                    displayName = propertyName;
            }

            return displayName;
        }
    }
}