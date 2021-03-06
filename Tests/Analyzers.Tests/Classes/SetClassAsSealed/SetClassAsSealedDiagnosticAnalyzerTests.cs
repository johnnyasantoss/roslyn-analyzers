﻿using Analyzers.AnalyzersMetadata.DiagnosticIdentifiers;
using Analyzers.AnalyzersMetadata.DiagnosticMessageFormats;
using Analyzers.CodeAnalysis.Classes.SetClassAsSealed;
using Analyzers.Tests._TestEnvironment.Base;
using Analyzers.Tests._TestEnvironment.Roslyn.DiagnosticAnalyzers;
using Microsoft.CodeAnalysis;
using Xunit;

namespace Analyzers.Tests.Classes.SetClassAsSealed
{
    public class SetClassAsSealedDiagnosticAnalyzerTests : CSharpDiagnosticAnalyzerTest<SetClassAsSealedDiagnosticAnalyzer>
    {
        public override string Filepath { get; } = "Classes/SetClassAsSealed/DiagnosticAnalyzer";

        [Fact]
        public void Empty_source_code_does_not_trigger_analyzer()
        {
            var source = string.Empty;
            VerifyNoDiagnosticTriggered(source);
        }

        [Theory]
        [InlineData("ClassWithAbstractEventField.cs")]
        [InlineData("ClassWithAbstractIndex.cs")]
        [InlineData("ClassWithAbstractMethod.cs")]
        [InlineData("ClassWithAbstractProperty.cs")]
        [InlineData("ClassWithStaticModifier.cs")]
        [InlineData("ClassWithVirtualEvent.cs")]
        [InlineData("ClassWithVirtualEventField.cs")]
        [InlineData("ClassWithVirtualIndex.cs")]
        [InlineData("ClassWithVirtualMethod.cs")]
        [InlineData("ClassWithVirtualProperty.cs")]
        public void Analyzer_is_not_triggered(string filename)
        {
            var source = ReadFile(filename);
            VerifyNoDiagnosticTriggered(source);
        }

        [Theory]
        [InlineData("ClassWithoutSealedModifier.cs", 3, 18)]
        public void Analyzer_is_triggered(string filename, int diagnosticLine, int diagnosticColumn)
        {
            var source = ReadFile(filename);
            var expectedDiagnostic = new DiagnosticResult
            {
                Id = ClassDiagnosticIdentifiers.SetClassAsSealed,
                Message = ClassDiagnosticMessageFormats.SetClassAsSealed.ToString(),
                Severity = DiagnosticSeverity.Warning,
                Locations = new[] { new DiagnosticResultLocation("Test0.cs", diagnosticLine, diagnosticColumn) }
            };

            VerifyDiagnostic(source, expectedDiagnostic);
        }
    }
}
