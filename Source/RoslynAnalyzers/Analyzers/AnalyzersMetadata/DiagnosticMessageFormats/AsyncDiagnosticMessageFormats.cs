﻿using Microsoft.CodeAnalysis;

namespace Analyzers.AnalyzersMetadata.DiagnosticMessageFormats
{
    public static class AsyncDiagnosticMessageFormats
    {
        public static readonly LocalizableString AsyncMethodNamesShouldBeSuffixedWithAsync = "Append asynchronous method name with Async";
        public static readonly LocalizableString AvoidAsyncVoidMethods = "Change the return type of the asyncronous method";
        public static readonly LocalizableString NonAsyncMethodNamesShouldNotBeSuffixedWithAsync = "Remove Async suffix from method name";
        public static readonly LocalizableString UseConfigureAwaitFalse = "Use ConfigureAwait(false)";
    }
}