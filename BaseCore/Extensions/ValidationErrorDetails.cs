﻿using FluentValidation.Results;

namespace BaseCore.Extensions
{
    /// <summary>
    /// Stands for validation errors. Must be used as a validation error object. 
    /// Validations errors can be stored as IEnumerable of type ValidationFailure.
    /// </summary>
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
    }
}