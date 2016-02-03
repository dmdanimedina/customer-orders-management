using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistema_fichas.Filters
{
    public class ModelBinder
    {
        public class DecimalModelBinder : DefaultModelBinder
        {
            public override object BindModel(ControllerContext controllerContext,
                                             ModelBindingContext bindingContext)
            {
                object result = null;

                string modelName = bindingContext.ModelName;
                string attemptedValue =
                    bindingContext.ValueProvider.GetValue(modelName).AttemptedValue;

                string wantedSeperator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
                string alternateSeperator = (wantedSeperator == "," ? "." : ",");

                if (attemptedValue.IndexOf(wantedSeperator) == -1 && attemptedValue.IndexOf(alternateSeperator) != -1)
                {
                    attemptedValue = attemptedValue.Replace(alternateSeperator, wantedSeperator);
                }

                try
                {
                    if (bindingContext.ModelMetadata.IsNullableValueType && string.IsNullOrWhiteSpace(attemptedValue))
                    {
                        return null;
                    }

                    result = decimal.Parse(attemptedValue, NumberStyles.Any);
                }
                catch (FormatException e)
                {
                    bindingContext.ModelState.AddModelError(modelName, e);
                }

                return result;
            }
        }
    }
}