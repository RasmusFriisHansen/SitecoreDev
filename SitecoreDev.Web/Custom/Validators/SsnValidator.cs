using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Sitecore.Data.Validators;

namespace SitecoreDev.Web.Custom.Validators
{
  [Serializable]
  public class SsnValidator : StandardValidator
  {
    private readonly string _ssnRegEx = @"^\d{3}-?\d{2}-?\d{4}$";

    public SsnValidator(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public SsnValidator()
    {
    }

    public override string Name => "SSN Validator";

    protected override ValidatorResult Evaluate()
    {
      var value = GetControlValidationValue();
      if (!string.IsNullOrEmpty(value) && Regex.IsMatch(value, _ssnRegEx))
        return ValidatorResult.Valid;
      Text = "SSN is not valid";
      return GetFailedResult(ValidatorResult.Error);
    }

    protected override ValidatorResult GetMaxValidatorResult()
    {
      return GetFailedResult(ValidatorResult.Error);
    }
  }
}