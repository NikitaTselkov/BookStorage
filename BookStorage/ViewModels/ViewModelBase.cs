using Prism.Mvvm;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using BookStorage.Models;
using System.Globalization;
using Core.Enums;

namespace BookStorage.ViewModels
{
    public class ViewModelBase : BindableBase, IDataErrorInfo
    {
        public virtual string this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();

                var property = GetType().GetProperty(columnName);
                Contract.Assert(null != property);

                var validationContext = new ValidationContext(this)
                {
                    MemberName = columnName
                };

                var isValid = Validator.TryValidateProperty(property.GetValue(this), validationContext, validationResults);
                if (isValid)
                {
                    return null;
                }

                return validationResults.First().ErrorMessage;
            }
        }

        public virtual string Error
        {
            get
            {
                var propertyInfos = GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

                foreach (var propertyInfo in propertyInfos)
                {
                    var errorMsg = this[propertyInfo.Name];
                    if (null != errorMsg)
                    {
                        return errorMsg;
                    }
                }

                return null;
            }
        }

        internal static void SetLanguage(Languages language)
        {
            TranslationSource.Instance.CurrentCulture = new CultureInfo(language.ToString());
        }

        internal bool IsAllValid()
        {
            return string.IsNullOrEmpty(Error);
        }

        internal bool IsValid(string propertyName)
        {
            return string.IsNullOrEmpty(this[propertyName]);
        }
    }
}
