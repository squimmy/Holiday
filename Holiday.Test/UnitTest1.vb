Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public NotInheritable Class UnitTest1
    <TestMethod()>
    Public Sub EmptyFileProducesEmptyDocument()
        Dim input = New String() {}
        Dim expectedOutput = New String() {}
        Dim actualOutput = Program.Fold(input)
        UnitTest1.AreEqual(expectedOutput, actualOutput, StringComparer.InvariantCulture)
    End Sub

    <TestMethod()>
    Public Sub SingleCreateParagraphProducesSingleParagraph()
        Dim input = {"CreateParagraph singleParagraph document 0 This is a single paragraph."}
        Dim expectedOutput = {"This is a single paragraph."}
        UnitTest1.TestFold(input, expectedOutput)
    End Sub

    <TestMethod()>
    Public Sub CreateHeadingCreateParagraphProducesHeadingContainingParagraph()
        Dim input = {"CreateHeading singleHeading document 0 Single Heading",
                     "CreateParagraph singleParagraph singleHeading 0 This is a single paragraph."}
        Dim expectedOutput = {"#Single Heading",
                              "This is a single paragraph."}
        UnitTest1.TestFold(input, expectedOutput)
    End Sub

    <TestMethod()>
    Public Sub Test1()
        Dim input = {"CreateParagraph singleParagraph document 0 This is a single paragraph.",
                     "CreateHeading singleHeading document 0 Single Heading",
                     "MoveNode singleParagraph singleHeading 0"}
        Dim expectedOutput = {"#Single Heading",
                              "This is a single paragraph."}
        UnitTest1.TestFold(input, expectedOutput)
    End Sub

    <TestMethod()>
    Public Sub Test2()
        Dim input = {"CreateParagraph singleParagraph document 0 This is a single paragraph.",
                     "DeleteNode singleParagraph"}
        Dim expectedOutput = New String() {}
        UnitTest1.TestFold(input, expectedOutput)
    End Sub

    <TestMethod(), ExpectedException(GetType(InvalidOperationException))>
    Public Sub Test3()
        Dim input = {"CreateParagraph singleParagraph document 0 This is a single paragraph.",
                     "CreateParagraph singleParagraph document 0 This is a also single paragraph."}
        Dim expectedOutput = Nothing
        UnitTest1.TestFold(input, expectedOutput)
    End Sub

    Public Shared Sub TestFold(input As IEnumerable(Of String), expectedOutput As IReadOnlyList(Of String))
        Dim actualOutput = Program.Fold(input)
        UnitTest1.AreEqual(expectedOutput, actualOutput, StringComparer.InvariantCulture)
    End Sub

    Public Shared Sub AreEqual(Of T)(expected As IReadOnlyList(Of T), actual As IReadOnlyList(Of T), comparer As IEqualityComparer(Of T))
        If expected Is Nothing AndAlso actual Is Nothing Then Exit Sub
        If expected Is Nothing Then Assert.Fail("Expected null, actual {0}", actual)
        If actual Is Nothing Then Assert.Fail("Expected {0}, actual null", expected)

        If expected.Count <> actual.Count Then Assert.Fail("Different lengths; expected {0}, actual {1}", expected.Count, actual.Count)

        For i = 0 To expected.Count - 1
            If Not comparer.Equals(expected(i), actual(i)) Then Assert.Fail("Different items at position {0}; expected '{1}', actual '{2}'", i, expected(i), actual(i))
        Next
    End Sub
End Class