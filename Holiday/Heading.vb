Public NotInheritable Class Heading
    Implements INode
    Implements INodeContainer

    Private ReadOnly _Contents As New List(Of INode)()

    Public Text As String

    Public Property Parent As INodeContainer Implements INode.Parent

    Public Iterator Function GetLines(headingLevel As Integer) As IEnumerable(Of String) Implements INode.GetLines
        Yield New String("#"c, headingLevel) & Text
        For Each node In _Contents
            For Each line In node.GetLines(headingLevel + 1)
                Yield line
            Next
        Next
    End Function

    Public ReadOnly Property Contents As List(Of INode) Implements INodeContainer.Contents
        Get
            Return _Contents
        End Get
    End Property
End Class
